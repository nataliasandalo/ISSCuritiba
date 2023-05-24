﻿using NFSE.Net.Layouts.ISSNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFSE.Net.Envio
{
    public class EnvioCompleto
    {
        public void SalvarLoteRps(EnviarLoteRpsEnvio lote, Core.ArquivosEnvio localArquivos)
        {
            if (string.IsNullOrWhiteSpace(localArquivos.SalvarEnvioLoteEm))
                throw new ArgumentNullException("localArquivos.SalvarEnvioLoteEm");
            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(localArquivos.SalvarEnvioLoteEm)))
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(localArquivos.SalvarEnvioLoteEm));

            var serializar = new Layouts.Serializador();
            serializar.SalvarXml<EnviarLoteRpsEnvio>(lote, localArquivos.SalvarEnvioLoteEm);
        }

        public Core.RespostaEnvioNFSe EnviarLoteRps(Core.Empresa empresa, Core.ArquivosEnvio localArquivos)
        {
            try
            {
                var serializar = new Layouts.Serializador();
                var envio = new NFSE.Net.Envio.Processar();
                var lote = serializar.LerXml<EnviarLoteRpsEnvio>(localArquivos.SalvarEnvioLoteEm);

                ExecutarConsultas(() =>
                {
                    envio.ProcessaArquivo(empresa, localArquivos.SalvarEnvioLoteEm, localArquivos.SalvarRetornoEnvioLoteEm, Servicos.RecepcionarLoteRps);
                });

                bool erro = false;
                var respostaEnvioLote = serializar.TryLerXml<EnviarLoteRpsResposta>(localArquivos.SalvarRetornoEnvioLoteEm, out erro);
                while (true)
                {
                    System.Threading.Thread.Sleep(1000);
                    var respostaSituacao = ConsultarSituacaoLote(empresa, respostaEnvioLote, localArquivos);
                    if (respostaSituacao.Items[0] is ListaMensagemRetorno)
                    {
                        if (((ListaMensagemRetorno)respostaSituacao.Items[0]).MensagemRetorno[0].Codigo == "E92")  //Lote ainda em processamento, tentando denovo.
                            continue;
                        //else if (((ListaMensagemRetorno)respostaSituacao.Items[0]).MensagemRetorno[0].Codigo == "E10")  //RPS já enviado, passar para o Consulta RPS e verificar se a data de emissão é a mesma
                        //{
                        //    var respostaRps = ConsultarRps(empresa, lote.LoteRps.ListaRps[0].InfRps.IdentificacaoRps, localArquivos);
                        //    var listaErros = new ListaMensagemRetorno() { MensagemRetorno = respostaRps.ListaMensagemRetorno.Length > 0 ? respostaRps.ListaMensagemRetorno : null };
                        //    return MontarResposta(lote, listaErros, null, respostaRps);
                        //}
                        return MontarResposta(lote, (ListaMensagemRetorno)respostaSituacao.Items[0], null, null);
                    }
                    else
                        break;
                }
                var respostaLote = ConsultarLote(empresa, respostaEnvioLote, localArquivos);
                return MontarResposta(lote, null, respostaLote.ListaNfse, null);
            }
            catch (System.Reflection.TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }

        public Core.RespostaCancelamentoNfse CancelarNfse(CancelarNfseEnvio envioCancelamento, Core.Empresa empresa, Core.ArquivosEnvio localArquivos)
        {
            try
            {
                ValidarCaminhos(localArquivos);
                var serializar = new Layouts.Serializador();
                serializar.SalvarXml<CancelarNfseEnvio>(envioCancelamento, localArquivos.SalvarCancelarNfseEnvioEm);

                var envio = new NFSE.Net.Envio.Processar();
                ExecutarConsultas(() =>
                {
                    envio.ProcessaArquivo(empresa, localArquivos.SalvarCancelarNfseEnvioEm, localArquivos.SalvarCancelarNfseRespostaEm, Servicos.CancelarNfse);
                });

                bool erro = false;
                var respostaEnvioLote = serializar.TryLerXml<CancelarNfseReposta>(localArquivos.SalvarCancelarNfseRespostaEm, out erro);
                if (respostaEnvioLote != null)
                {
                    if (respostaEnvioLote.Item is ListaMensagemRetorno)
                    {
                        var retorno = new Core.RespostaCancelamentoNfse();
                        ListaMensagemRetorno mensagensErro = (ListaMensagemRetorno)respostaEnvioLote.Item;
                        retorno.Sucesso = false;
                        retorno.CodigoErro = mensagensErro.MensagemRetorno[0].Codigo;
                        retorno.Correcao = mensagensErro.MensagemRetorno[0].Correcao;
                        retorno.MensagemErro = mensagensErro.MensagemRetorno[0].Mensagem;
                        return retorno;
                    }
                    else
                    {
                        var retorno = new Core.RespostaCancelamentoNfse();
                        tcCancelamentoNfse cancelamento = (tcCancelamentoNfse)respostaEnvioLote.Item;
                        retorno.Sucesso = cancelamento.Confirmacao.InfConfirmacaoCancelamento.Sucesso;
                        retorno.DataHoraCancelamento = cancelamento.Confirmacao.InfConfirmacaoCancelamento.DataHora;
                        retorno.NumeroNfse = cancelamento.Confirmacao.Pedido.InfPedidoCancelamento.IdentificacaoNfse.Numero;
                        return retorno;
                    }
                }
                else
                    return new Core.RespostaCancelamentoNfse() { Sucesso = false, CodigoErro = "00", MensagemErro = "Erro desconhecido" };
            }
            catch (System.Reflection.TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }

        private ConsultarSituacaoLoteRpsResposta ConsultarSituacaoLote(Core.Empresa empresa, EnviarLoteRpsResposta protocolo, Core.ArquivosEnvio localArquivos)
        {
            var consultaSituacaoLote = new ConsultarSituacaoLoteRpsEnvio();
            consultaSituacaoLote.Prestador = new tcIdentificacaoPrestador();
            consultaSituacaoLote.Prestador.Cnpj = empresa.CNPJ;
            consultaSituacaoLote.Prestador.InscricaoMunicipal = empresa.InscricaoMunicipal;
            consultaSituacaoLote.Protocolo = protocolo.Items[2].ToString();

            var serializar = new Layouts.Serializador();
            serializar.SalvarXml<ConsultarSituacaoLoteRpsEnvio>(consultaSituacaoLote, localArquivos.SalvarConsultaSituacaoLoteEm);

            var envio = new NFSE.Net.Envio.Processar();
            ExecutarConsultas(() =>
            {
                envio.ProcessaArquivo(empresa, localArquivos.SalvarConsultaSituacaoLoteEm, localArquivos.SalvarRetornoConsultaSituacaoLoteEm, Servicos.ConsultarSituacaoLoteRps);
            });

            return serializar.LerXml<ConsultarSituacaoLoteRpsResposta>(localArquivos.SalvarRetornoConsultaSituacaoLoteEm);
        }

        private ConsultarLoteRpsResposta ConsultarLote(Core.Empresa empresa, EnviarLoteRpsResposta protocolo, Core.ArquivosEnvio localArquivos)
        {
            var consultaSituacaoLote = new ConsultarLoteRpsEnvio();
            consultaSituacaoLote.Prestador = new tcIdentificacaoPrestador();
            consultaSituacaoLote.Prestador.Cnpj = empresa.CNPJ;
            consultaSituacaoLote.Prestador.InscricaoMunicipal = empresa.InscricaoMunicipal;
            consultaSituacaoLote.Protocolo = protocolo.Items[2].ToString();

            var serializar = new Layouts.Serializador();
            serializar.SalvarXml<ConsultarLoteRpsEnvio>(consultaSituacaoLote, localArquivos.SalvarConsultaLoteRpsEnvioEm);

            var envio = new NFSE.Net.Envio.Processar();

            ExecutarConsultas(() =>
            {
                envio.ProcessaArquivo(empresa, localArquivos.SalvarConsultaLoteRpsEnvioEm, localArquivos.SalvarConsultaLoteRpsRespostaEm, Servicos.ConsultarLoteRps);
            });

            return serializar.LerXml<ConsultarLoteRpsResposta>(localArquivos.SalvarConsultaLoteRpsRespostaEm);
        }

        private ConsultarNfseRpsResposta ConsultarRps(Core.Empresa empresa, tcIdentificacaoRps rps, Core.ArquivosEnvio localArquivos)
        {
            var consultaRps = new ConsultarNfsePorRpsEnvio();
            consultaRps.Prestador = new tcIdentificacaoPrestador();
            consultaRps.Prestador.Cnpj = empresa.CNPJ;
            consultaRps.Prestador.InscricaoMunicipal = empresa.InscricaoMunicipal;
            consultaRps.IdentificacaoRps = rps;

            var serializar = new Layouts.Serializador();
            serializar.SalvarXml<ConsultarNfsePorRpsEnvio>(consultaRps, localArquivos.SalvarConsultaLoteRpsEnvioEm);

            var envio = new NFSE.Net.Envio.Processar();

            ExecutarConsultas(() =>
            {
                envio.ProcessaArquivo(empresa, localArquivos.SalvarConsultaLoteRpsEnvioEm, localArquivos.SalvarConsultaLoteRpsRespostaEm, Servicos.ConsultarNfsePorRps);
            });

            return serializar.LerXml<ConsultarNfseRpsResposta>(localArquivos.SalvarConsultaLoteRpsRespostaEm);
        }

        private Core.RespostaEnvioNFSe MontarResposta(EnviarLoteRpsEnvio lote, ListaMensagemRetorno listaRetorno, ConsultarLoteRpsRespostaListaNfse respostaConsulta, ConsultarNfseRpsResposta respostaRps)
        {
            var resposta = new Core.RespostaEnvioNFSe();
            int indice = 0;
            foreach (var item in lote.LoteRps.ListaRps)
            {
                var resp = new Core.ItemResposta();
                resp.LoteEnvio = lote.LoteRps.NumeroLote;
                resp.NumeroRps = item.InfRps.IdentificacaoRps.Numero;
                resp.Serie = item.InfRps.IdentificacaoRps.Serie;
                resp.Identificacao = item.InfRps.Id;

                if (listaRetorno != null && listaRetorno.MensagemRetorno != null)
                {
                    resp.Sucesso = false;
                    if (indice > 0 && listaRetorno.MensagemRetorno.Length > 1)
                    {
                        resp.CodigoErro = listaRetorno.MensagemRetorno[indice].Codigo;
                        resp.MensagemErro = listaRetorno.MensagemRetorno[indice].Mensagem;
                        resp.Correcao = listaRetorno.MensagemRetorno[indice].Correcao;
                    }
                    else
                    {
                        resp.CodigoErro = listaRetorno.MensagemRetorno[0].Codigo;
                        resp.MensagemErro = listaRetorno.MensagemRetorno[0].Mensagem;
                        resp.Correcao = listaRetorno.MensagemRetorno[0].Correcao;
                    }
                }
                else if (respostaConsulta != null)
                {
                    resp.Sucesso = true;
                    resp.IdentificacaoRetorno = respostaConsulta.ComplNfse[indice].Nfse.InfNfse.CodigoVerificacao;
                    resp.UrlConsulta = respostaConsulta.ComplNfse[indice].Nfse.InfNfse.OutrasInformacoes;
                }
                else if (respostaRps != null)
                {
                    resp.Sucesso = true;
                    resp.Identificacao = respostaRps.ComplNfse.Nfse.InfNfse.CodigoVerificacao;
                    resp.UrlConsulta = respostaRps.ComplNfse.Nfse.InfNfse.OutrasInformacoes;
                }
                resposta.Add(resp);
                indice++;
            }
            return resposta;
        }

        private void ExecutarConsultas(Action acao)
        {
            int tentativas = 0;
            while (true)
            {
                try
                {
                    acao.Invoke();
                    break;
                }
                catch (Exception)
                {
                    if (tentativas == 5)
                        throw;
                    tentativas++;
                    System.Threading.Thread.Sleep(500);
                }
            }
        }

        private void ValidarCaminhos(Core.ArquivosEnvio localArquivos)
        {
            if (string.IsNullOrWhiteSpace(localArquivos.SalvarCancelarNfseEnvioEm))
                throw new ArgumentNullException("localArquivos.SalvarEnvioLoteEm");
            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(localArquivos.SalvarCancelarNfseEnvioEm)))
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(localArquivos.SalvarCancelarNfseEnvioEm));

            if (string.IsNullOrWhiteSpace(localArquivos.SalvarCancelarNfseRespostaEm))
                throw new ArgumentNullException("localArquivos.SalvarEnvioLoteEm");
            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(localArquivos.SalvarCancelarNfseRespostaEm)))
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(localArquivos.SalvarCancelarNfseRespostaEm));
        }

    }
}
