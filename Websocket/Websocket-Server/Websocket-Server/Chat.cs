using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Websocket_Server
{
    // Task I:  Modify this websocket behavior so that it remembers all messages.
    //          Whenever there is a new client connected, send all stored messages to the client
    //          so the client knows the history of the conversation.
    // Task II: Add timestamp (just the hour and minute) to the messages
    //          (see http://stackoverflow.com/questions/21219797/how-to-get-correct-timestamp-in-c-sharp
    //           for an example on how to get a timestamp).
    class Chat : WebSocketBehavior
    {

        public List<string> chatLog = new List<string>();

        protected override void OnOpen()
        {
            foreach(string s in chatLog)
            {
                Sessions.SendTo(ID, s);
            }
        }

        /// <summary>
        /// Gets the time stamp of the user
        /// </summary>
        /// <param name="value">Time being passed in</param>
        /// <returns></returns>
        public static string GetTimeStamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            // Retrieve message from client
            string msg = e.Data;

            string timeStamp = GetTimeStamp(DateTime.Now);
            chatLog.Add(timeStamp + ": " + msg);

            // Broadcast message to all clients
            Sessions.Broadcast(msg);
        }
    }
}
