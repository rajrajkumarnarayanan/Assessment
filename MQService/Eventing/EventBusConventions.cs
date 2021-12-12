using EasyNetQ;
using System;

namespace Eventing
{
    public sealed class EventBusConventions : Conventions
    {
        public EventBusConventions(ITypeNameSerializer typeNameSerializer) : base(typeNameSerializer)
        {
            ExchangeNamingConvention = type =>
            {
                QueueAttribute MyAttribute = (QueueAttribute)Attribute.GetCustomAttribute(type, typeof(QueueAttribute));
                return MyAttribute.ExchangeName;
            };
            RpcRoutingKeyNamingConvention = type =>
            {
                QueueAttribute MyAttribute = (QueueAttribute)Attribute.GetCustomAttribute(type, typeof(QueueAttribute));
                return MyAttribute.QueueName;
            };           
        }
    }
}
