﻿using NFSE.Net.Certificado;
using NFSE.Net.Core;
using NFSE.Net.Implementacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFSE.Net.Envio
{
    public class TaskConsultarNfsePorRps : TaskAbst
    {
        public override void Execute(Empresa empresa)
        {
            //Definir o serviço que será executado para a classe
            Servico = Servicos.ConsultarNfsePorRps;

            //Ler o XML para pegar parâmetros de envio
            LerXML ler = new LerXML();
            ler.PedSitNfseRps(NomeArquivoXML, empresa);

            //Criar objetos das classes dos serviços dos webservices do SEFAZ
            WebServiceProxy wsProxy = null;
            object pedLoteRps = null;
            string cabecMsg = "";
            PadroesNFSe padraoNFSe = Functions.PadraoNFSe(ler.oDadosPedSitNfseRps.cMunicipio);
            switch (padraoNFSe)
            {
                case PadroesNFSe.GINFES:
                    wsProxy = ConfiguracaoApp.DefinirWS(Servico, empresa, ler.oDadosPedSitNfseRps.cMunicipio, ler.oDadosPedSitNfseRps.tpAmb, ler.oDadosPedSitNfseRps.tpEmis);
                    pedLoteRps = wsProxy.CriarObjeto(NomeClasseWS(Servico, ler.oDadosPedSitNfseRps.cMunicipio));
                    cabecMsg = "<ns2:cabecalho versao=\"3\" xmlns:ns2=\"http://www.ginfes.com.br/cabecalho_v03.xsd\"><versaoDados>3</versaoDados></ns2:cabecalho>";
                    break;

                case PadroesNFSe.BETHA:
                    wsProxy = new WebServiceProxy(empresa.X509Certificado);
                    wsProxy.Betha = new Betha();
                    break;

                case PadroesNFSe.THEMA:
                    wsProxy = ConfiguracaoApp.DefinirWS(Servico, empresa, ler.oDadosPedSitNfseRps.cMunicipio, ler.oDadosPedSitNfseRps.tpAmb, ler.oDadosPedSitNfseRps.tpEmis);
                    pedLoteRps = wsProxy.CriarObjeto(NomeClasseWS(Servico, ler.oDadosPedSitNfseRps.cMunicipio));
                    break;

                case PadroesNFSe.CANOAS_RS:
                    wsProxy = ConfiguracaoApp.DefinirWS(Servico, empresa, ler.oDadosPedSitNfseRps.cMunicipio, ler.oDadosPedSitNfseRps.tpAmb, ler.oDadosPedSitNfseRps.tpEmis);
                    pedLoteRps = wsProxy.CriarObjeto(NomeClasseWS(Servico, ler.oDadosPedSitNfseRps.cMunicipio));
                    cabecMsg = "<cabecalho versao=\"201001\"><versaoDados>V2010</versaoDados></cabecalho>";
                    break;

                case PadroesNFSe.ISSNET:
                    wsProxy = ConfiguracaoApp.DefinirWS(Servico, empresa, ler.oDadosPedSitNfseRps.cMunicipio, ler.oDadosPedSitNfseRps.tpAmb, ler.oDadosPedSitNfseRps.tpEmis);
                    pedLoteRps = wsProxy.CriarObjeto(NomeClasseWS(Servico, ler.oDadosPedSitNfseRps.cMunicipio));
                    break;

                case PadroesNFSe.ISSONLINE:
                    wsProxy = ConfiguracaoApp.DefinirWS(Servico, empresa, ler.oDadosPedSitNfseRps.cMunicipio, ler.oDadosPedSitNfseRps.tpAmb, ler.oDadosPedSitNfseRps.tpEmis);
                    pedLoteRps = wsProxy.CriarObjeto(NomeClasseWS(Servico, ler.oDadosPedSitNfseRps.cMunicipio));
                    break;

                case PadroesNFSe.BLUMENAU_SC:
                    wsProxy = ConfiguracaoApp.DefinirWS(Servico, empresa, ler.oDadosPedSitNfseRps.cMunicipio, ler.oDadosPedSitNfseRps.tpAmb, ler.oDadosPedSitNfseRps.tpEmis);
                    pedLoteRps = wsProxy.CriarObjeto(NomeClasseWS(Servico, ler.oDadosPedSitNfseRps.cMunicipio));
                    break;

                case PadroesNFSe.BHISS:
                    wsProxy = ConfiguracaoApp.DefinirWS(Servico, empresa, ler.oDadosPedSitNfseRps.cMunicipio, ler.oDadosPedSitNfseRps.tpAmb, ler.oDadosPedSitNfseRps.tpEmis);
                    pedLoteRps = wsProxy.CriarObjeto(NomeClasseWS(Servico, ler.oDadosPedSitNfseRps.cMunicipio));
                    cabecMsg = "<cabecalho xmlns=\"http://www.abrasf.org.br/nfse.xsd\" versao=\"1.00\"><versaoDados >1.00</versaoDados ></cabecalho>";
                    break;

                case PadroesNFSe.GIF:
                    wsProxy = ConfiguracaoApp.DefinirWS(Servico, empresa, ler.oDadosPedSitNfseRps.cMunicipio, ler.oDadosPedSitNfseRps.tpAmb, ler.oDadosPedSitNfseRps.tpEmis);
                    pedLoteRps = wsProxy.CriarObjeto(NomeClasseWS(Servico, ler.oDadosPedSitNfseRps.cMunicipio));
                    break;

                case PadroesNFSe.DUETO:
                    wsProxy = ConfiguracaoApp.DefinirWS(Servico, empresa, ler.oDadosPedSitNfseRps.cMunicipio, ler.oDadosPedSitNfseRps.tpAmb, ler.oDadosPedSitNfseRps.tpEmis, padraoNFSe);
                    pedLoteRps = wsProxy.CriarObjeto(NomeClasseWS(Servico, ler.oDadosPedSitNfseRps.cMunicipio));
                    break;

                case PadroesNFSe.WEBISS:
                    wsProxy = ConfiguracaoApp.DefinirWS(Servico, empresa, ler.oDadosPedSitNfseRps.cMunicipio, ler.oDadosPedSitNfseRps.tpAmb, ler.oDadosPedSitNfseRps.tpEmis, padraoNFSe);
                    pedLoteRps = wsProxy.CriarObjeto(NomeClasseWS(Servico, ler.oDadosPedSitNfseRps.cMunicipio));
                    cabecMsg = "<cabecalho xmlns=\"http://www.abrasf.org.br/nfse.xsd\" versao=\"1.00\"><versaoDados >1.00</versaoDados ></cabecalho>";
                    break;

                case PadroesNFSe.PAULISTANA:
                    wsProxy = ConfiguracaoApp.DefinirWS(Servico, empresa, ler.oDadosPedSitNfseRps.cMunicipio, ler.oDadosPedSitNfseRps.tpAmb, ler.oDadosPedSitNfseRps.tpEmis);
                    pedLoteRps = wsProxy.CriarObjeto(NomeClasseWS(Servico, ler.oDadosPedSitNfseRps.cMunicipio));
                    break;

                case PadroesNFSe.SALVADOR_BA:
                    wsProxy = ConfiguracaoApp.DefinirWS(Servico, empresa, ler.oDadosPedSitNfseRps.cMunicipio, ler.oDadosPedSitNfseRps.tpAmb, ler.oDadosPedSitNfseRps.tpEmis, padraoNFSe);
                    pedLoteRps = wsProxy.CriarObjeto(NomeClasseWS(Servico, ler.oDadosPedSitNfseRps.cMunicipio));
                    break;

                case PadroesNFSe.PORTOVELHENSE:
                    wsProxy = ConfiguracaoApp.DefinirWS(Servico, empresa, ler.oDadosPedSitNfseRps.cMunicipio, ler.oDadosPedSitNfseRps.tpAmb, ler.oDadosPedSitNfseRps.tpEmis, padraoNFSe);
                    pedLoteRps = wsProxy.CriarObjeto(NomeClasseWS(Servico, ler.oDadosPedSitNfseRps.cMunicipio));
                    cabecMsg = "<cabecalho versao=\"2.00\" xmlns:ns2=\"http://www.w3.org/2000/09/xmldsig#\" xmlns=\"http://www.abrasf.org.br/nfse.xsd\"><versaoDados>2.00</versaoDados></cabecalho>";
                    break;

                case PadroesNFSe.PRONIN:
                    wsProxy = ConfiguracaoApp.DefinirWS(Servico, empresa, ler.oDadosPedSitNfseRps.cMunicipio, ler.oDadosPedSitNfseRps.tpAmb, ler.oDadosPedSitNfseRps.tpEmis, padraoNFSe);
                    pedLoteRps = wsProxy.CriarObjeto(NomeClasseWS(Servico, ler.oDadosPedSitNfseRps.cMunicipio));
                    break;

                default:
                    throw new Exception("Não foi possível detectar o padrão da NFS-e.");
            }

            if (padraoNFSe != PadroesNFSe.IPM)
            {
                //Assinar o XML
                AssinaturaDigital ad = new AssinaturaDigital();
                ad.Assinar(NomeArquivoXML, empresa, Convert.ToInt32(ler.oDadosPedSitNfseRps.cMunicipio));

                //Invocar o método que envia o XML para o SEFAZ
                oInvocarObj.InvocarNFSe(wsProxy, pedLoteRps, NomeMetodoWS(Servico, ler.oDadosPedSitNfseRps.cMunicipio, empresa.tpAmb), cabecMsg, this, "-ped-sitnfserps", "-sitnfserps", padraoNFSe, Servico, empresa);
            }
        }
    }
}
