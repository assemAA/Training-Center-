using ITI_Project.Models;

namespace ITI_Project.viewModels
{
    public class InstractorDepartementviewModel
    {
        public int Id { get; set; }
        public string Ins_name { get; set; }

        public string Ins_address { get; set; }

        public double Ins_salary { get; set; }

        public string Ins_imag { get; set; }

        public int Ins_dept { get; set; }
        public List<Departement> departements { get; set; }


    }
}
