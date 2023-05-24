using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFSE.Net.Layouts.ISSNET
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://isscuritiba.curitiba.pr.gov.br/iss/nfse.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://isscuritiba.curitiba.pr.gov.br/iss/nfse.xsd", IsNullable = false)]
    public partial class CancelarNfseEnvio
    {

        private tcPedidoCancelamento pedidoField;

        /// <remarks/>
        public tcPedidoCancelamento Pedido
        {
            get
            {
                return this.pedidoField;
            }
            set
            {
                this.pedidoField = value;
            }
        }
    }
}
