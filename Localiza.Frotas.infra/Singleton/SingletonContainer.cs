using System;
using System.Collections.Generic;
using System.Text;

namespace Localiza.Frotas.infra.Singleton
{
    public class SingletonContainer
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
