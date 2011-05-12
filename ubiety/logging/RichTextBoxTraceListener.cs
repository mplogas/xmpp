// RichTextBoxTraceListener.cs
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

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ubiety.logging
{
	/// <summary>
	/// Trace listener that outputs to a RichTextBox
	/// </summary>
	public class RichTextBoxTraceListener : TraceListener
	{
		private delegate void AppendDelegate(string message);
		private readonly RichTextBox _target;
		private readonly AppendDelegate _invokeAppend;

		///<summary>
		///</summary>
		///<param name="target"></param>
		public RichTextBoxTraceListener(RichTextBox target)
		{
			_invokeAppend = Append;
			_target = target;
		}

		/// <summary>
		/// When overridden in a derived class, writes the specified message to the listener you create in the derived class.
		/// </summary>
		/// <param name="message">A message to write. </param><filterpriority>2</filterpriority>
		public override void Write(string message)
		{
			_target.Invoke(_invokeAppend, new object[] { message });
		}

		/// <summary>
		/// When overridden in a derived class, writes a message to the listener you create in the derived class, followed by a line terminator.
		/// </summary>
		/// <param name="message">A message to write. </param><filterpriority>2</filterpriority>
		public override void WriteLine(string message)
		{
			_target.Invoke(_invokeAppend, new object[] { message + Environment.NewLine });
		}

		private void Append(string message)
		{
			_target.Text += message;
		}
	}
}
