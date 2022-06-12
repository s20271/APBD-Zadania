namespace cwiczenie6.Models
{
    public class Prescription_Medicament
    {
        public int IdMedicament { get; set; }
        public int IdPresciption { get; set; }
        public virtual Medicament Medicament { get; set; }
        public virtual Prescription Prescription { get; set; }
        public int Dose { get; set; }
        public string Details { get; set; }

    }
}
