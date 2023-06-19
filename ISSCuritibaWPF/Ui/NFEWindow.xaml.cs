using System;
using System.Collections.Generic;
using System;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using NFSE.Net;

namespace ISSCuritibaWPF.Ui
{
    public partial class NFEWindow : Window
    {
        public NFEWindow()
        {
            InitializeComponent();
        }

        [STAThread]
        public static void Main()
        {
            // Create and run the application
            Application app = new Application();
            app.Run(new NFEWindow());
        }

        private NFSE.Net.Layouts.ISSNET.EnviarLoteRpsEnvio RetornarRps()
        {
            NFSE.Net.Layouts.ISSNET.EnviarLoteRpsEnvio envio = new NFSE.Net.Layouts.ISSNET.EnviarLoteRpsEnvio();
            envio.LoteRps = new NFSE.Net.Layouts.ISSNET.tcLoteRps();
            envio.LoteRps.Cnpj = "03657739000169";
            envio.LoteRps.Id = "1400";
            envio.LoteRps.InscricaoMunicipal = "24082-6";
            envio.LoteRps.NumeroLote = "1400";
            envio.LoteRps.QuantidadeRps = 1;
            envio.LoteRps.ListaRps = new NFSE.Net.Layouts.ISSNET.tcRps[1] { new NFSE.Net.Layouts.ISSNET.tcRps() };
            envio.LoteRps.ListaRps[0].InfRps = new NFSE.Net.Layouts.ISSNET.tcInfRps();
            envio.LoteRps.ListaRps[0].InfRps.Id = "rps1AA";
            envio.LoteRps.ListaRps[0].InfRps.IdentificacaoRps = new NFSE.Net.Layouts.ISSNET.tcIdentificacaoRps();
            envio.LoteRps.ListaRps[0].InfRps.IdentificacaoRps.Numero = "1";
            envio.LoteRps.ListaRps[0].InfRps.IdentificacaoRps.Serie = "AA";
            envio.LoteRps.ListaRps[0].InfRps.IdentificacaoRps.Tipo = 1;
            envio.LoteRps.ListaRps[0].InfRps.DataEmissao = DateTime.Now;
            envio.LoteRps.ListaRps[0].InfRps.NaturezaOperacao = 1;
            envio.LoteRps.ListaRps[0].InfRps.RegimeEspecialTributacao = 1;
            envio.LoteRps.ListaRps[0].InfRps.RegimeEspecialTributacaoSpecified = true;
            envio.LoteRps.ListaRps[0].InfRps.OptanteSimplesNacional = 1;
            envio.LoteRps.ListaRps[0].InfRps.IncentivadorCultural = 2;
            envio.LoteRps.ListaRps[0].InfRps.Status = 1;

            envio.LoteRps.ListaRps[0].InfRps.Servico = new NFSE.Net.Layouts.ISSNET.tcDadosServico();
            envio.LoteRps.ListaRps[0].InfRps.Servico.ItemListaServico = "0105";
            envio.LoteRps.ListaRps[0].InfRps.Servico.Discriminacao = "Serviço de venda";
            envio.LoteRps.ListaRps[0].InfRps.Servico.CodigoMunicipio = 4204202;
            envio.LoteRps.ListaRps[0].InfRps.Servico.Valores = new NFSE.Net.Layouts.ISSNET.tcValores();
            envio.LoteRps.ListaRps[0].InfRps.Servico.Valores.ValorServicos = 1;
            envio.LoteRps.ListaRps[0].InfRps.Servico.Valores.IssRetido = 2;
            envio.LoteRps.ListaRps[0].InfRps.Servico.Valores.ValorIss = 0.04M;
            envio.LoteRps.ListaRps[0].InfRps.Servico.Valores.ValorIssSpecified = true;
            envio.LoteRps.ListaRps[0].InfRps.Servico.Valores.BaseCalculo = 1;
            envio.LoteRps.ListaRps[0].InfRps.Servico.Valores.BaseCalculoSpecified = true;
            envio.LoteRps.ListaRps[0].InfRps.Servico.Valores.Aliquota = 4;
            envio.LoteRps.ListaRps[0].InfRps.Servico.Valores.AliquotaSpecified = true;

            envio.LoteRps.ListaRps[0].InfRps.Prestador = new NFSE.Net.Layouts.ISSNET.tcIdentificacaoPrestador();
            envio.LoteRps.ListaRps[0].InfRps.Prestador.Cnpj = "03657739000169";
            envio.LoteRps.ListaRps[0].InfRps.Prestador.InscricaoMunicipal = "24082-6";

            envio.LoteRps.ListaRps[0].InfRps.Tomador = new NFSE.Net.Layouts.ISSNET.tcDadosTomador();
            envio.LoteRps.ListaRps[0].InfRps.Tomador.IdentificacaoTomador = new NFSE.Net.Layouts.ISSNET.tcIdentificacaoTomador();
            envio.LoteRps.ListaRps[0].InfRps.Tomador.IdentificacaoTomador.CpfCnpj = new NFSE.Net.Layouts.ISSNET.tcCpfCnpj() { ItemElementName = NFSE.Net.Layouts.ISSNET.ItemChoiceType.Cnpj, Item = "09072780000150" };
            envio.LoteRps.ListaRps[0].InfRps.Tomador.RazaoSocial = "Mecanica Boa Viagem";
            envio.LoteRps.ListaRps[0].InfRps.Tomador.Endereco = new NFSE.Net.Layouts.ISSNET.tcEndereco();
            envio.LoteRps.ListaRps[0].InfRps.Tomador.Endereco.Endereco = "Rua do comercio";
            envio.LoteRps.ListaRps[0].InfRps.Tomador.Endereco.Numero = "15";
            envio.LoteRps.ListaRps[0].InfRps.Tomador.Endereco.Bairro = "Centro";
            envio.LoteRps.ListaRps[0].InfRps.Tomador.Endereco.CodigoMunicipio = 4204350;
            envio.LoteRps.ListaRps[0].InfRps.Tomador.Endereco.CodigoMunicipioSpecified = true;
            envio.LoteRps.ListaRps[0].InfRps.Tomador.Endereco.Uf = "SC";
            envio.LoteRps.ListaRps[0].InfRps.Tomador.Endereco.Cep = 88032050;
            envio.LoteRps.ListaRps[0].InfRps.Tomador.Endereco.CepSpecified = true;

            envio.LoteRps.ListaRps[0].InfRps.Tomador.Contato = new NFSE.Net.Layouts.ISSNET.tcContato();
            envio.LoteRps.ListaRps[0].InfRps.Tomador.Contato.Email = "email@email.com.br";
            envio.LoteRps.ListaRps[0].InfRps.Tomador.Contato.Telefone = "32386621";


            envio.LoteRps.ListaRps[0].InfRps.CondicaoPagamento = new NFSE.Net.Layouts.ISSNET.tcCondicaoPagamento();
            envio.LoteRps.ListaRps[0].InfRps.CondicaoPagamento.Condicao = "3- A Prazo";
            envio.LoteRps.ListaRps[0].InfRps.CondicaoPagamento.QtdParcela = 2;

            envio.LoteRps.ListaRps[0].InfRps.CondicaoPagamento.Parcelas = new NFSE.Net.Layouts.ISSNET.tcParcela[1] { new NFSE.Net.Layouts.ISSNET.tcParcela() };
            envio.LoteRps.ListaRps[0].InfRps.CondicaoPagamento.Parcelas[0].DataVencimento = DateTime.Now.ToString();
            envio.LoteRps.ListaRps[0].InfRps.CondicaoPagamento.Parcelas = new NFSE.Net.Layouts.ISSNET.tcParcela[1] { new NFSE.Net.Layouts.ISSNET.tcParcela() };
            envio.LoteRps.ListaRps[0].InfRps.CondicaoPagamento.Parcelas[0].DataVencimento = DateTime.Now.ToString();

            envio.LoteRps.ListaRps[1].InfRps = new NFSE.Net.Layouts.ISSNET.tcInfRps();
            envio.LoteRps.ListaRps[1].InfRps.Id = "rps2AA";
            envio.LoteRps.ListaRps[1].InfRps.IdentificacaoRps = new NFSE.Net.Layouts.ISSNET.tcIdentificacaoRps();
            envio.LoteRps.ListaRps[1].InfRps.IdentificacaoRps.Numero = "2";
            envio.LoteRps.ListaRps[1].InfRps.IdentificacaoRps.Serie = "AA";
            envio.LoteRps.ListaRps[1].InfRps.IdentificacaoRps.Tipo = 1;
            envio.LoteRps.ListaRps[1].InfRps.DataEmissao = DateTime.Now;
            envio.LoteRps.ListaRps[1].InfRps.NaturezaOperacao = 1;
            envio.LoteRps.ListaRps[1].InfRps.RegimeEspecialTributacao = 1;
            envio.LoteRps.ListaRps[1].InfRps.RegimeEspecialTributacaoSpecified = true;
            envio.LoteRps.ListaRps[1].InfRps.OptanteSimplesNacional = 1;
            envio.LoteRps.ListaRps[1].InfRps.IncentivadorCultural = 2;
            envio.LoteRps.ListaRps[1].InfRps.Status = 1;

            envio.LoteRps.ListaRps[1].InfRps.Servico = new NFSE.Net.Layouts.ISSNET.tcDadosServico();
            envio.LoteRps.ListaRps[1].InfRps.Servico.ItemListaServico = "0105";
            envio.LoteRps.ListaRps[1].InfRps.Servico.Discriminacao = "Serviço de venda";
            envio.LoteRps.ListaRps[1].InfRps.Servico.CodigoMunicipio = 4204202;
            envio.LoteRps.ListaRps[1].InfRps.Servico.Valores = new NFSE.Net.Layouts.ISSNET.tcValores();
            envio.LoteRps.ListaRps[1].InfRps.Servico.Valores.ValorServicos = 1;
            envio.LoteRps.ListaRps[1].InfRps.Servico.Valores.IssRetido = 2;
            envio.LoteRps.ListaRps[1].InfRps.Servico.Valores.ValorIss = 0.04M;
            envio.LoteRps.ListaRps[1].InfRps.Servico.Valores.BaseCalculo = 1;
            envio.LoteRps.ListaRps[1].InfRps.Servico.Valores.Aliquota = 4;

            envio.LoteRps.ListaRps[1].InfRps.Prestador = new NFSE.Net.Layouts.ISSNET.tcIdentificacaoPrestador();
            envio.LoteRps.ListaRps[1].InfRps.Prestador.Cnpj = "03657739000169";
            envio.LoteRps.ListaRps[1].InfRps.Prestador.InscricaoMunicipal = "24082-6";

            envio.LoteRps.ListaRps[1].InfRps.Tomador = new NFSE.Net.Layouts.ISSNET.tcDadosTomador();
            envio.LoteRps.ListaRps[1].InfRps.Tomador.IdentificacaoTomador = new NFSE.Net.Layouts.ISSNET.tcIdentificacaoTomador();
            envio.LoteRps.ListaRps[1].InfRps.Tomador.IdentificacaoTomador.CpfCnpj = new NFSE.Net.Layouts.ISSNET.tcCpfCnpj() { ItemElementName = NFSE.Net.Layouts.ISSNET.ItemChoiceType.Cnpj, Item = "09072780000150" };
            envio.LoteRps.ListaRps[1].InfRps.Tomador.RazaoSocial = "Mecanica Boa Viagem";
            envio.LoteRps.ListaRps[1].InfRps.Tomador.Endereco = new NFSE.Net.Layouts.ISSNET.tcEndereco();
            envio.LoteRps.ListaRps[1].InfRps.Tomador.Endereco.Endereco = "Rua do comercio";
            envio.LoteRps.ListaRps[1].InfRps.Tomador.Endereco.Numero = "15";
            envio.LoteRps.ListaRps[1].InfRps.Tomador.Endereco.Bairro = "Centro";
            envio.LoteRps.ListaRps[1].InfRps.Tomador.Endereco.CodigoMunicipio = 4204350;
            envio.LoteRps.ListaRps[1].InfRps.Tomador.Endereco.CodigoMunicipioSpecified = true;
            envio.LoteRps.ListaRps[1].InfRps.Tomador.Endereco.Uf = "SC";
            envio.LoteRps.ListaRps[1].InfRps.Tomador.Endereco.Cep = 88032050;
            envio.LoteRps.ListaRps[1].InfRps.Tomador.Endereco.CepSpecified = true;

            envio.LoteRps.ListaRps[1].InfRps.Tomador.Contato = new NFSE.Net.Layouts.ISSNET.tcContato();
            envio.LoteRps.ListaRps[1].InfRps.Tomador.Contato.Email = "email@email.com.br";
            envio.LoteRps.ListaRps[1].InfRps.Tomador.Contato.Telefone = "32386621";
            return envio;
        }

        private void GerarRpsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string caminhoXml = @"C:\NotasEletronicas\1-Interfoc Soluções\nfse\1-env.xml";

                NFSE.Net.Layouts.ISSNET.EnviarLoteRpsEnvio envio = RetornarRps();

                if (File.Exists(caminhoXml))
                    File.Delete(caminhoXml);

                var serializar = new NFSE.Net.Layouts.Serializador();
                serializar.SalvarXml<NFSE.Net.Layouts.ISSNET.EnviarLoteRpsEnvio>(envio, caminhoXml);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EnviarRpsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string caminhoXml = @"C:\Users\danimaribeiro\Documents\Nota_Servico\NOVOS_RPS\1-env.xml";
                System.Net.ServicePointManager.Expect100Continue = false;

                var envio = new NFSE.Net.Envio.Processar();
                var empresa = RetornaEmpresa(false);
                envio.ProcessaArquivo(empresa, caminhoXml, "", Servicos.RecepcionarLoteRps);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private NFSE.Net.Core.Empresa RetornaEmpresa(bool criptografado)
        {
            var empresa = new NFSE.Net.Core.Empresa();
            empresa.Nome = "Empresa teste";
            empresa.CNPJ = "03657739000169";
            empresa.InscricaoMunicipal = "24082-6";
            empresa.CertificadoArquivo = @"C:\Users\natal\Desktop\Sapiens\Ilton - NFE\SAPIENS SOFTWARE HOUSE LTDA47182245000140.pfx";
            if (criptografado)
                empresa.CertificadoSenha = NFSE.Net.Certificado.Criptografia.criptografaSenha("Abacaxicomcoco1!");
            else
                empresa.CertificadoSenha = "Abacaxicomcoco1!";

            empresa.tpAmb = 2;
            empresa.tpEmis = 1;
            empresa.CodigoMunicipio = 4106902;
            return empresa;
        }

        private void ConsultarSituacaoLoteBtn_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para consultar situação do lote

            string caminhoXml = @"C:\Users\danimaribeiro\Documents\Nota_Servico\NOVOS_RPS\1-consulta-situacao-lote.xml";

            var consultaSituacaoLote = new NFSE.Net.Layouts.ISSNET.ConsultarSituacaoLoteRpsEnvio();
            consultaSituacaoLote.Prestador = new NFSE.Net.Layouts.ISSNET.tcIdentificacaoPrestador();
            consultaSituacaoLote.Prestador.Cnpj = "03657739000169";
            consultaSituacaoLote.Prestador.InscricaoMunicipal = "24082-6";
            consultaSituacaoLote.Protocolo = "855426049227311";

            if (System.IO.File.Exists(caminhoXml))
                System.IO.File.Delete(caminhoXml);

            var serializar = new NFSE.Net.Layouts.Serializador();
            serializar.SalvarXml<NFSE.Net.Layouts.ISSNET.ConsultarSituacaoLoteRpsEnvio>(consultaSituacaoLote, caminhoXml);

            caminhoXml = @"C:\Users\danimaribeiro\Documents\Visual Studio 2012\Projects\NFSE.Net\NFSE.Net.Tests\bin\Debug\PastaRetorno\1-env.xml-ret-loterps.xml";
            System.Net.ServicePointManager.Expect100Continue = false;

            var empresa = RetornaEmpresa(false);
            var envio = new NFSE.Net.Envio.Processar();
            envio.ProcessaArquivo(empresa, caminhoXml, "", Servicos.ConsultarSituacaoLoteRps);
        }

        private void ConsultarLoteBtn_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para consultar lote RPS
            System.Net.ServicePointManager.Expect100Continue = false;


            string caminhoXml = @"C:\NotasEletronicas\30-JeF DISTRIBUIDORA DE\nfse\513-ped-loterps.xml";
            string caminhoSalvar = @"C:\NotasEletronicas\30-JeF DISTRIBUIDORA DE\nfse\513-lote-final.xml";
            var empresa = RetornaEmpresa(false);

            var envio = new NFSE.Net.Envio.Processar();

            envio.ProcessaArquivo(empresa, caminhoXml, caminhoSalvar, Servicos.ConsultarLoteRps);

            var serializar = new NFSE.Net.Layouts.Serializador();
            var retorno = serializar.LerXml<NFSE.Net.Layouts.ISSNET.ConsultarLoteRpsResposta>(caminhoSalvar);

            System.Diagnostics.Process.Start(retorno.ListaNfse.ComplNfse[0].Nfse.InfNfse.OutrasInformacoes);
        }

        private void GravarInformacaoEmpresaBtn_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para gravar informação da empresa
            try
            {
                var empresa = RetornaEmpresa(true);
                Empresas.SalvarNovaEmpresa(empresa, "03657739000169", "Empresa Teste");

                NFSE.Net.Core.Empresa.CarregarEmpresasConfiguradas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void EnvioCompletoBtn_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para envio completo
            System.Net.ServicePointManager.Expect100Continue = false;
            NFSE.Net.Layouts.ISSNET.EnviarLoteRpsEnvio envio = RetornarRps();
            NFSE.Net.Core.Empresa empresa = RetornaEmpresa(false);

            var envioCompleto = new NFSE.Net.Envio.EnvioCompleto();

            var localSalvarArquivo = NFSE.Net.Core.ArquivosEnvio.GerarCaminhos(envio.LoteRps.Id, System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NotaServico"));
            envioCompleto.SalvarLoteRps(envio, localSalvarArquivo);
            var resposta = envioCompleto.EnviarLoteRps(empresa, localSalvarArquivo);
            foreach (var item in resposta)
            {
                MessageBox.Show(item.MensagemErro);
            }
        }

        private void ConsultarRpsBtn_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para consultar RPS
            try
            {
                string caminhoXml = @"C:\NotasEletronicas\30-JeF DISTRIBUIDORA DE\nfse\496-ped-loterps.xml";
                string caminhoSalvar = @"C:\NotasEletronicas\30-JeF DISTRIBUIDORA DE\nfse\496-consulta-por-rps.xml";
                var empresa = RetornaEmpresa(false);
                var envio = new NFSE.Net.Envio.Processar();
                envio.ProcessaArquivo(empresa, caminhoXml, caminhoSalvar, Servicos.ConsultarNfsePorRps);
                var serializar = new NFSE.Net.Layouts.Serializador();
                var retorno = serializar.LerXml<NFSE.Net.Layouts.ISSNET.ConsultarNfseRpsResposta>(caminhoSalvar);
                System.Diagnostics.Process.Start(retorno.ComplNfse.Nfse.InfNfse.OutrasInformacoes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CancelamentoNFSeBtn_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para cancelar NFSe
            try
            {
                var empresa = RetornaEmpresa(false);
                var localArquivos = NFSE.Net.Core.ArquivosEnvio.GerarCaminhos("", @"C:\NotasEletronicas\30-JeF DISTRIBUIDORA DE\nfse\cancelamento");

                var envio = new NFSE.Net.Envio.EnvioCompleto();

                NFSE.Net.Layouts.ISSNET.CancelarNfseEnvio nfseCancelar = new NFSE.Net.Layouts.ISSNET.CancelarNfseEnvio();
                nfseCancelar.Pedido = new NFSE.Net.Layouts.ISSNET.tcPedidoCancelamento();
                nfseCancelar.Pedido.InfPedidoCancelamento = new NFSE.Net.Layouts.ISSNET.tcInfPedidoCancelamento();
                nfseCancelar.Pedido.InfPedidoCancelamento.CodigoCancelamento = "123";
                nfseCancelar.Pedido.InfPedidoCancelamento.Id = "123";
                nfseCancelar.Pedido.InfPedidoCancelamento.IdentificacaoNfse = new NFSE.Net.Layouts.ISSNET.tcIdentificacaoNfse();
                nfseCancelar.Pedido.InfPedidoCancelamento.IdentificacaoNfse.Cnpj = "03657739000169";
                nfseCancelar.Pedido.InfPedidoCancelamento.IdentificacaoNfse.CodigoMunicipio = 4204202;
                nfseCancelar.Pedido.InfPedidoCancelamento.IdentificacaoNfse.InscricaoMunicipal = "4545";
                nfseCancelar.Pedido.InfPedidoCancelamento.IdentificacaoNfse.Numero = "125456";

                var resposta = envio.CancelarNfse(nfseCancelar, empresa, localArquivos);

                if (resposta.Sucesso)
                {
                    MessageBox.Show(resposta.DataHoraCancelamento.ToLongDateString());
                }
                else
                {
                    MessageBox.Show(resposta.CodigoErro + " - " + resposta.MensagemErro + " - " + resposta.Correcao);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}