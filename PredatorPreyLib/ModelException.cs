namespace PredatorPreyLib
{
    /// <summary>
    /// Класс исключений, связанных с посстроением модели
    /// </summary>
    [System.Serializable]
    public class ModelException : System.Exception
    {
        public ModelException() { }
        public ModelException(string message) : base(message) { }
        public ModelException(string message, System.Exception inner) : base(message, inner) { }
        protected ModelException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}