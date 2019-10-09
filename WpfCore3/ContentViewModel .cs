using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Disposables;
using System.Text;

namespace WpfCore3
{
    public class ContentViewModel : IConfirmNavigationRequest, IRegionMemberLifetime, IDisposable, INotifyPropertyChanged
    {
#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067

        private IRegionNavigationService RegionNavigationService { get; set; }

        public bool KeepAlive => false;

        private CompositeDisposable DisposeCollection = new CompositeDisposable();
        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        [SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed")]
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DisposeCollection.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose() => Dispose(true);
        #endregion

        public ContentModel Model { get; }

        public ContentViewModel(ContentModel _model)
        {
            Model = _model;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback) => continuationCallback(true);

        public void OnNavigatedTo(NavigationContext navigationContext) => RegionNavigationService = navigationContext.NavigationService;

        public void OnNavigatedFrom(NavigationContext navigationContext) => Dispose();
    }
}
