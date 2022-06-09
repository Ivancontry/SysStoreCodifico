using System.Collections.Generic;

namespace SysStore.Domain.Base
{
    public class DomainValidation
    {
        public Dictionary<string, string> Fallos { get; private set; }
        public bool IsValid { get => Fallos.Count == 0; }
        public DomainValidation()
        {
            Fallos = new Dictionary<string, string>();
            Fallos.Clear();
        }
        public void AddFailed(string key, string error)
        {
            Fallos.Add(key, error);
        }
    }
}
