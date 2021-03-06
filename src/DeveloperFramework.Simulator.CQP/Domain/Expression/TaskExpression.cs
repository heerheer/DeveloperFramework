﻿using DeveloperFramework.Simulator.CQP.Domain.Context;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperFramework.Simulator.CQP.Domain.Expositor
{
	/// <summary>
	/// 任务表达式, 该类是抽象的
	/// </summary>
	public abstract class TaskExpression
	{
		/// <summary>
		/// 获取当前实例关联的模拟器
		/// </summary>
		public CQPSimulator Simulator { get; }

		/// <summary>
		/// 初始化 <see cref="TaskExpression"/> 类的新实例
		/// </summary>
		/// <param name="simulator">任务表达式关联的模拟器</param>
		public TaskExpression (CQPSimulator simulator)
		{
			this.Simulator = simulator;
		}

		/// <summary>
		/// 在派生类中重写时, 处理任务上下文的具体解释
		/// </summary>
		/// <param name="context">要解析的任务上下文</param>
		/// <returns>若完成解析则为 <see langword="true"/> 否则为 <see langword="false"/></returns>
		public abstract bool Interpret (TaskContext context);
	}
}
