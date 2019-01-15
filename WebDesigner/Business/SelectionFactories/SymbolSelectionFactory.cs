using EPiServer.Shell.ObjectEditing;
using System.Collections.Generic;
namespace AlloyTraining.Business.SelectionFactories
{
    public class SymbolSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new List<SelectItem>
            {
                new SelectItem { Value = "fa fa-pencil", Text = "Pencil" },
                new SelectItem { Value = "fa fa-book", Text = "Book" },
                new SelectItem { Value = "fa fa-rocket", Text = "Rocket" }
            };
        }
    }
}