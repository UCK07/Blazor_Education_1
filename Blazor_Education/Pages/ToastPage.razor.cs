using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor_Education.Pages
{
    public partial class ToastPage
    {

        [Inject] protected IToastService _toast {  get; set; }

        public void ClickShoToast()
        {
            _toast.ShowSuccess("Success ");
            _toast.ShowError("Error");
            _toast.ShowToast(ToastLevel.Info, "Heyy");
            _toast.ShowInfo("umut");
        }


    }


}
