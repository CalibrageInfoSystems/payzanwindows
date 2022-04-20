using Caliburn.Micro;
using Kulman.WPA81.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.Framework.Contracts.Pocos
{
  public  class QRViewModel 
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDialogService _dialogService;

        public QRViewModel(IEventAggregator eventAggregator, IDialogService dialogService)
        {
            _eventAggregator = eventAggregator;
            _dialogService = dialogService;
        }

        //protected override  void OnActivate()
        //{
        //    base.OnActivate();
        //    _eventAggregator.Subscribe(this);
        //}

        //protected override void OnDeactivate(bool close)
        //{
        //     base.OnDeactivate(close);

        //    _eventAggregator.Unsubscribe(this);
        //}

        public void Handle(QRCodemessage message)
        {
            _dialogService.ShowMessageDialog(message.Result, "QRReader");
        }
    }

}
