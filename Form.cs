using System;

namespace TimeAura.PolymorphicBinding
{
    public enum FormType { T1, T2 }
    public abstract class Form
    {
        protected abstract FormType FormType { get; }
        protected Guid Id { get; set; }
    }
    public class T1Form : Form
    {
        public string T1Property1 { get; set; }
        public string T1Property2 { get; set; }
        protected override FormType FormType => FormType.T1;
    }
    public class T2Form : Form
    {
        public string T2Property1 { get; set; }
        public string T2Property2 { get; set; }
        protected override FormType FormType => FormType.T2;
    }
}