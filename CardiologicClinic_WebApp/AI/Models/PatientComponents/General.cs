namespace CardiologicClinic_WebApp.AI.Models.PatientComponents
{
    class General
    {
        int age;
        bool sex;

        public General(int ageToSet, bool sexToSet)
        {
            this.age = ageToSet;
            this.sex = sexToSet;
        }
    }
}
