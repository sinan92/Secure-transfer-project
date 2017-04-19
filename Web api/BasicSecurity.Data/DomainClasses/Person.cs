namespace BasicSecurity.Data.DomainClasses
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public byte[] PrivateKey { get; set; }
        public byte[] PublicKey { get; set; }
        public byte[] File { get; set; }
    }
}
