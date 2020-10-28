﻿using SoftWareHelper.Helpers;
using SoftWareHelper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace SoftWareHelper.ViewModels
{
    public class MainVM:ViewModelBase
    {
        #region 属性
        private ObservableCollection<ApplicationModel> _applicationList;
        /// <summary>
        /// 所有应用集合
        /// </summary>
        public ObservableCollection<ApplicationModel> ApplicationList
        {
            get { return _applicationList; }
            set
            {
                _applicationList = value;
                this.NotifyPropertyChange("ApplicationList");
            }
        }
        #endregion

        #region 构造

        #endregion

        #region 命令
        /// <summary>
        /// loaded
        /// </summary>    
        public ICommand ViewLoaded => new RelayCommand(obj =>
        {
            
            Common.TemporaryFile();
            if (!File.Exists(Common.temporaryApplicationJson))
            {
                ApplicationList = Common.AllApplictionInstalled();
                string json = JsonHelper.Serialize(ApplicationList);
                FileHelper.WriteFile(json, Common.temporaryApplicationJson);
            }
            else
            {
                string json = FileHelper.ReadFile(Common.temporaryApplicationJson);
                ApplicationList = JsonHelper.Deserialize<ObservableCollection<ApplicationModel>>(json);
            }

        });
        #endregion

        #region 方法

        #endregion

    }
}
