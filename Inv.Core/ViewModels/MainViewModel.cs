using MvvmCross.Commands;
using MvvmCross.Navigation;
using System.Net.Http;
using System.Threading.Tasks;
using Inventory.Core.Models;
using Inventory.Core.Rest.Interfaces;

namespace Inventory.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        private readonly IRestClient _restClient;

        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowPeopleViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<LoginViewModel>());
            //ShowPlanetsViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<PlanetsViewModel>());
            //ShowMenuViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<MenuViewModel>());
        }

        public Task<PagedResult<Users>> GetPeopleAsync(string url = null)
        {
            return string.IsNullOrEmpty(url)
                         ? _restClient.MakeApiCall<PagedResult<Users>>($"{Constants.BaseUrl}/people/", HttpMethod.Get)
                         : _restClient.MakeApiCall<PagedResult<Users>>(url, HttpMethod.Get);
        }

        // MvvmCross Lifecycle

        // MVVM Properties

        // MVVM Commands
        public IMvxAsyncCommand ShowPeopleViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowPlanetsViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowMenuViewModelCommand { get; private set; }

        // Private methods
    }
}
