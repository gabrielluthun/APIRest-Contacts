namespace APIContacts
{
    public class Contact
    {
        #region Attributs, méthode et constructeur
        private int? _id;
        private string? _nom;
        private string? _prenom;
        private DateTime? _date_naissance;
        private string? _genre;
        private string? _avatar;

        public int? Id { get => _id; set => _id = value; }
        public string? Nom { get => _nom; set => _nom = value; }
        public string? Prenom { get => _prenom; set => _prenom = value; }
        public DateTime? Date_naissance { get => _date_naissance; set => _date_naissance = value; }
        public string? Genre { get => _genre; set => _genre = value; }
        public string? Avatar { get => _avatar; set => _avatar = value; }

         public Contact() {
            Id = 1;
            Nom = "Doe";
            Prenom = "John";
            Date_naissance = new DateTime(2000, 1, 1);
            Genre = "M";
        } 
        #endregion
    }
}
