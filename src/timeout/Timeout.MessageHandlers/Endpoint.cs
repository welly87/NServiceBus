﻿using System.Configuration;
using NServiceBus;
using NServiceBus.Host;

namespace Timeout.MessageHandlers
{
    class Endpoint : IConfigureThisEndpoint,
        AsA_Server,
        ISpecify.MyOwn.Serialization
    {
        public void Init(Configure configure)
        {
            string nameSpace = ConfigurationManager.AppSettings["NameSpace"];
            string serialization = ConfigurationManager.AppSettings["Serialization"];

            switch (serialization)
            {
                case "xml":
                    configure.XmlSerializer(nameSpace);
                    break;
                case "binary":
                    configure.BinarySerializer();
                    break;
                default:
                    throw new ConfigurationErrorsException("Serialization can only be one of 'interfaces', 'xml', or 'binary'.");
            }
        }
    }
}
