// Logger.cs
//
//Ubiety XMPP Library Copyright (C) 2011 Dieter Lunn
//
//This library is free software; you can redistribute it and/or modify it under
//the terms of the GNU Lesser General Public License as published by the Free
//Software Foundation; either version 3 of the License, or (at your option)
//any later version.
//
//This library is distributed in the hope that it will be useful, but WITHOUT
//ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
//FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
//
//You should have received a copy of the GNU Lesser General Public License along
//with this library; if not, write to the Free Software Foundation, Inc., 59
//Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System.Diagnostics;

namespace ubiety.logging
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class Logger
	{
		///<summary>
		///</summary>
		private Logger()
		{
			Trace.Listeners.Add(new TextWriterTraceListener("ubiety.log", "logListener"));
		}

		static Logger()
		{
			Instance = new Logger();
		}

		///<summary>
		///</summary>
		///<param name="sender"></param>
		///<param name="message"></param>
		public static void Debug(object sender, string message)
		{
			Trace.TraceInformation(message);
		}

		/// <summary>
		/// Debugs the format.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="format">The format.</param>
		/// <param name="args">The args.</param>
		public static void DebugFormat(object sender, string format, params object[] args)
		{
			Trace.TraceInformation(format, args);
		}

		/// <summary>
		/// Infoes the specified sender.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="message">The message.</param>
		public static void Info(object sender, string message)
		{
			Trace.TraceInformation(message);
		}

		/// <summary>
		/// Infoes the format.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The args.</param>
		public static void InfoFormat(object sender, string format, params object[] args)
		{
			Trace.TraceInformation(format, args);
		}

		/// <summary>
		/// Errors the specified sender.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="message">The message.</param>
		public static void Error(object sender, string message)
		{
			Trace.TraceError(message);
		}

		/// <summary>
		/// Errors the format.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The args.</param>
		public static void ErrorFormat(object sender, string format, params object[] args)
		{
			Trace.TraceError(format, args);
		}

		///<summary>
		///</summary>
		public static Logger Instance { get; private set; }
	}
}
