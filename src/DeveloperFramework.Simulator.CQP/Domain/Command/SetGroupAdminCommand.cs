﻿using DeveloperFramework.CQP;
using DeveloperFramework.LibraryModel.CQP;
using DeveloperFramework.Log.CQP;
using DeveloperFramework.SimulatorModel.CQP;
using DeveloperFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DeveloperFramework.Simulator.CQP.Domain.Command
{   /// <summary>
    ///  置群管理命令
    /// </summary>
    [FunctionBinding(Function = nameof(CQPExport.CQ_setGroupAdmin))]
    public class SetGroupAdminCommand : AbstractCommand
    {
        #region --常量--
        public const string TYPE_GROUP_ADMIN = "群管理变更";
        #endregion

        #region --属性--
        public long GroupId { get; }
        public long QqId { get; }
        public bool IsSet { get; }
        #endregion

        #region --构造函数--
        public SetGroupAdminCommand(CQPSimulator simulator, CQPSimulatorApp app, bool isAuth, long groupId, long qqId, bool isSet)
            : base(simulator, app, isAuth)
        {
            this.GroupId = groupId;
            this.QqId = qqId;
            this.IsSet = isSet;
        }
        #endregion

        #region --公开方法--
        public override object ExecuteHaveAuth()
        {
            throw new NotImplementedException();
        }

        public override object ExecuteHaveNoAuth()
        {
            AppInfo appInfo = this.App.Library.AppInfo;
            Logger.Instance.Info(appInfo.Name, TYPE_CHECK_AUTHORIZATION, $"检测到调用 Api [{nameof(CQPExport.CQ_setGroupAdmin)}] 未经授权, 请检查 app.json 是否赋予权限", null, null);
            return RESULT_API_UNAUTHORIZED;
        }
        #endregion
    }
}
