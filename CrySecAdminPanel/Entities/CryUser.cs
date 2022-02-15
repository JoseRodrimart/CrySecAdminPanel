namespace PanelAdmin.Entities
{
    public class CryUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string mail { get; set; }
        public string image { get; set; }
        //public Company company;
        public CryUser(int id, string name, string mail, string image)
        {
            this.id = id;
            this.name = name;
            this.mail = mail;
            this.image = image;
        }

        public string ToString()
        {
            return "CryUser:{id: " + id + " name: " + name + " mail: " + mail + " image: " + image + "}";
        }
    }
}