using System;
using System.Collections.Generic;
using System;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace ISSCuritibaWPF.Ui
{
    public partial class NFEWindow : Window
    {
        public NFEWindow()
        {
            InitializeComponent();
        }

        private NFSE.Net.Layouts.ISSNET.EnviarLoteRpsEnvio RetornarRps()
        {
            // Implemente a lógica para retornar os dados do objeto EnviarLoteRpsEnvio
            // de acordo com a sua aplicação
            var envio = new NFSE.Net.Layouts.ISSNET.EnviarLoteRpsEnvio();
            // Preencha os campos necessários do objeto envio
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
            // Lógica para enviar RPS
        }

        private void ConsultarSituacaoLoteBtn_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para consultar situação do lote
        }

        private void ConsultarLoteBtn_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para consultar lote RPS
        }

        private void GravarInformacaoEmpresaBtn_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para gravar informação da empresa
        }

        private void EnvioCompletoBtn_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para envio completo
        }

        private void ConsultarRpsBtn_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para consultar RPS
        }

        private void CancelamentoNFSeBtn_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para cancelar NFSe
        }
    }
}