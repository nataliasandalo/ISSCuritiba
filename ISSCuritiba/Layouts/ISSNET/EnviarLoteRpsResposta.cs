﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFSE.Net.Layouts.ISSNET
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class EnviarLoteRpsResposta
    {

        private object[] itemsField;

        private ItemsChoiceType3[] itemsElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DataRecebimento", typeof(System.DateTime))]
        [System.Xml.Serialization.XmlElementAttribute("NumeroLote", typeof(string), DataType = "nonNegativeInteger")]
        [System.Xml.Serialization.XmlElementAttribute("Protocolo", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("ListaMensagemRetorno", typeof(ListaMensagemRetorno), Namespace = "http://tempuri.org/tipos_complexos.xsd")]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType3[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }
    }

}
