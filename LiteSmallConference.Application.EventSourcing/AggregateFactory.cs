using LiteSmallConference.Application.EventSourcing.Exceptions;
using System;

namespace GeekLemonConference.Application.EventSourcing
{
    public static class AggregateFactory
    {
        public static T CreateAggregate<T>()
        {
            try
            {
                return (T)Activator.CreateInstance(typeof(T), true);
            }
            catch (MissingMethodException)
            {
                throw new MissingParameterLessConstructorException(typeof(T));
            }
        }
    }
}
