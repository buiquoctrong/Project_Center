/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package mychessmate.network;

/*import com.sun.security.ntlm.Server;*/
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.logging.Level;
import java.util.logging.Logger;
import mychessmate.Move;
import mychessmate.MyChessmate;

/**
 *
 * @author TranCamTu
 */

class Client implements Runnable //connecting client
{

    //Network fields
    private Socket s;
    public ObjectInputStream input;
    public ObjectOutputStream output;
    public String nick;
    private Table table;
    protected boolean wait4undoAnswer = false;
    
    // Game logic fields
    private boolean myTurn = false;
    private final static MyChessmate myChessmate = new MyChessmate();
    private Move move = new Move();
    private boolean isEndGame = false;

    
    //
    Client(Socket s, ObjectInputStream input, ObjectOutputStream output, String nick, Table table)
    {
        this.s = s;
        this.input = input;
        this.output = output;
        this.nick = nick;
        this.table = table;

        Thread thread = new Thread(this);
        thread.start();
    }

    @Override
    public void run() //listening
    {

        System.out.print("Client Virtual: running function: run()\n");
        boolean isOK = true;
        while (isOK)
        {
            try {
                String in = input.readUTF();

                switch (in) {
                    case "#move":
                        //new move
                        int source_location = input.readInt();
                        int destination = input.readInt();
                        table.sendMoveToOther(this, source_location, destination);
                        break;
                    case "#message":
                        //new message
                        String str = input.readUTF();
                        table.sendMessageToAll(nick + ": " + str);
                        break;
                    default:
                        break;
                }
            }
            catch (IOException ex)
            {
                Logger.getLogger(Server.class.getName()).log(Level.SEVERE, null, ex);
                isOK = false;
                try
                {
                    table.sendErrorConnectionToOther(this);
                }
                catch (IOException ex1)
                {
                    Logger.getLogger(Client.class.getName()).log(Level.SEVERE, null, ex1);
                }
            }

        }
    }
    
}
