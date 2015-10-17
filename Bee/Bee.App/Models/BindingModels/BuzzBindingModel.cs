namespace Bee.App.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class BuzzBindingModel
    {
        [Required]
        public string Content { get; set; }
    }
}