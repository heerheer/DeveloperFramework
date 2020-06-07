﻿using DeveloperFramework.LibraryModel.CQP;
using DeveloperFramework.Log.CQP;
using DeveloperFramework.Simulator.CQP.Domain.Context;
using DeveloperFramework.Simulator.CQP.Domain.Expositor;
using DeveloperFramework.SimulatorModel.CQP;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperFramework.Simulator.CQP.Domain.Expression
{
	/// <summary>
	/// 发送群消息的任务表达式
	/// </summary>
	public class SendGroupMessageExpression : TaskExpression
	{
		/// <summary>
		/// 初始化 <see cref="SendGroupMessageExpression"/> 类的新实例
		/// </summary>
		/// <param name="simulator">任务表达式关联的模拟器</param>
		public SendGroupMessageExpression (CQPSimulator simulator)
			: base (simulator)
		{
		}

		public override bool Interpret (TaskContext context)
		{
			if (context is GroupMessageTaskContext groupContext)
			{
				GroupMessageType subType = groupContext.SubType;
				Message msg = groupContext.Message;
				Group fromGroup = groupContext.FromGroup;
				QQ fromQQ = groupContext.FromQQ;
				GroupAnonymous fromAnonymous = groupContext.FromAnonymous;
				IntPtr font = groupContext.Font;

				// 存入消息列表
				this.Simulator.DataPool.MessageCollection.Add (msg);

				// 调用app
				this.Simulator.GroupMessage (subType, msg.Id, fromGroup, fromQQ, fromAnonymous == null ? string.Empty : fromAnonymous.ToBase64String (), msg, font);
				context.Stopwatch.Stop ();

				Logger.Instance.InfoReceive (CQPErrorCode.TYPE_MESSAGE_GROUP, $"群: {groupContext.FromGroup.Id} 账号: {groupContext.FromQQ.Id} {groupContext.Message.Text}", true, context.Stopwatch.Elapsed);
			}
			return false;
		}
	}
}
