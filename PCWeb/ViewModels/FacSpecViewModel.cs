using System.Numerics;

namespace PCWeb.ViewModels
{
    public class FacSpecViewModel
    {
        public IEnumerable<SpecModel> Specs { get; set; }
        public IEnumerable<FacultyModel> Faculties { get; set; }
    }
}
