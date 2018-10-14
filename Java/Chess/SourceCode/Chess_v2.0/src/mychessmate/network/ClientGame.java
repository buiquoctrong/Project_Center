/*
#
#
#
 */

/**
 * @author Quoc Trong
 */
package mychessmate.network;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.ConnectException;
import java.net.Socket;
import java.net.UnknownHostException;
import mychessmate.Move;
import mychessmate.MyChessmate;

/**
 * Class responsible for clients references:
 * for running game, for joining the game, adding moves
 */
public class ClientGame implements Runnable
{
    
    //private static final Logger LOG = Logger.getLogger(Client.class);

    public static boolean isPrintEnable = true;                 // In tất cả tin nhắn
    protected Socket socket;                                    // Tạo socket
    protected ObjectOutputStream output;                        // Dữ liệu Socket kiểu Object
    protected ObjectInputStream input;                              
    protected String ip;                                        // Địa chỉ IP
    protected int port;                                         // Port kết nối server
    protected boolean isObserver = false;                       // Kiểu Người xem
    protected MyChessmate game;
    public ClientGame(String ip, int port)                      // Khởi tạo với IP và port
    {
        print("Client running ");
        this.ip = ip;
        this.port = port;
    }

    /* Method responsible for joining to the server on 
     * witch the game was created
     */
    public int join(int tableID, boolean asPlayer, String nick, String password) throws Error //join to server
    {
        int servCode = 0; //GET ERROR FROM SERVER
        print("running function: join(" + tableID + ", " + asPlayer + ", " + nick + ")");
        try
        {
            print("join to server: ip:" + getIp() + " port:" + getPort());
            this.setIsObserver(!asPlayer);
            try
            {
                // Mở Socket
                setSocket(new Socket(getIp(), getPort()));
                setOutput(new ObjectOutputStream(getSocket().getOutputStream()));
                setInput(new ObjectInputStream(getSocket().getInputStream()));
                
                //Gửi dữ liệu tới Server
                print("send to server: table ID");
                getOutput().writeInt(tableID);
                print("send to server: player or observer");
                getOutput().writeBoolean(asPlayer);
                print("send to server: player nick");
                getOutput().writeUTF(nick);
                print("send to server: password");
                getOutput().writeUTF(password);
                getOutput().flush();

                servCode = getInput().readInt(); //Thông số truyền từ server
                print("connection info: " + Connection_info.get(servCode).name());
                if (Connection_info.get(servCode).name().startsWith("err_"))
                {
                    throw new Error(Connection_info.get(servCode).name());
                }
                if (servCode == Connection_info.all_is_ok.getValue())
                {
                    Thread thread = new Thread(this);
                    thread.start();
                    return 0;    // có thể kết nối
                }
                else    //một số lỗi khác từ server
                {
                    return servCode;
                }
            }
            catch (Error | ConnectException err)
            {
                return servCode;
            }
        }
        catch (UnknownHostException ex)
        {
            return servCode;
        }
        catch (IOException ex)
        {
            return servCode;
        }
    }

    /* Method responsible for running of the game
     */
    @Override
    public void run()
    {
        print("123.running function: run()");
        boolean isOK = true;
        while (isOK)
        {
            try
            {
                String in = getInput().readUTF();
                print("input code: " + in);

                switch (in) {
                //getting new move from server
                    case "#move":
                        int beginX = getInput().readInt();
                        int beginY = getInput().readInt();
                        getGame().setNewMove(new Move(beginX, beginY));
                        break;
                //getting message from server
                    case "#message":
                        String str = getInput().readUTF();
                        //getGame().getChat().addMessage(str);
                        break;
                    case "#StartGame":
                        getGame().startGame();
                        print("Here");
                        break;
                    case "#errorConnection":
                        break;
                    default:
                        break;
                }
            }
            catch (IOException ex)
            {
                isOK = false;
                //getGame().getChat().addMessage("** "+Settings.lang("error_connecting_to_server")+" **");
            }
        }
    }
    
    /* Method responsible for sending the move witch was taken by a player
     */
    public void sendMove(int beginX, int beginY) //sending new move to server
    {
        print("running function: sendMove(" + beginX + ", " + beginY + ")");
        try
        {
            getOutput().writeUTF("#move");
            getOutput().writeInt(beginX);
            getOutput().writeInt(beginY);
            getOutput().flush();
        }
        catch (IOException ex)
        {
            //LOG.error("IOException, message: " + ex.getMessage() + " object: " + ex);
        }
    }
    
    public void sendUndoAnswerPositive()
    {
        try
        {
            getOutput().writeUTF("#undoAnswerPositive");
            getOutput().flush();
        }
        catch(IOException ex)
        {
            //LOG.error("IOException, message: " + ex.getMessage() + " object: " + ex);
        }        
    }
    
    public void sendUndoAnswerNegative()
    {
        try
        {
            getOutput().writeUTF("#undoAnswerNegative");
            getOutput().flush();
        }
        catch(IOException ex)
        {
            //LOG.error("IOException, message: " + ex.getMessage() + " object: " + ex);
        }        
    }    
    
    /* Method responsible for sending to the server informations about
     * moves of a player
     */
    public void sendMassage(String str) //sending new move to server
    {
        print("running function: sendMessage(" + str + ")");
        try
        {
            getOutput().writeUTF("#message");
            getOutput().writeUTF(str);
            getOutput().flush();
        }
        catch (IOException ex)
        {
            //LOG.error("IOException, message: " + ex.getMessage() + " object: " + ex);
        }
    }

    private void print(String str){
        System.out.println(str);
    }
    /**
     * @return the game
     */
    public MyChessmate getGame()
    {
        return game;
    }

    /**
     * @param game the game to set
     */
    public void setGame(MyChessmate game)
    {
        this.game = game;
    }

    /**
     * return the socket
     * @return socket
     */
    public Socket getSocket()
    {
        return socket;
    }

    /**
     * @param socket the socket to set
     */
    public void setSocket(Socket socket)
    {
        this.socket = socket;
    }

    /**
     * @return the output
     */
    public ObjectOutputStream getOutput()
    {
        return output;
    }

    /**
     * @param output the output to set
     */
    public void setOutput(ObjectOutputStream output)
    {
        this.output = output;
    }

    /**
     * @return the input
     */
    public ObjectInputStream getInput()
    {
        return input;
    }

    /**
     * @param input the input to set
     */
    public void setInput(ObjectInputStream input)
    {
        this.input = input;
    }

    /**
     * @return the ip
     */
    public String getIp()
    {
        return ip;
    }

    /**
     * @param ip the ip to set
     */
    public void setIp(String ip)
    {
        this.ip = ip;
    }

    /**
     * @return the port
     */
    public int getPort()
    {
        return port;
    }

    /**
     * @param port the port to set
     */
    public void setPort(int port)
    {
        this.port = port;
    }

    /**
     * @return the isObserver
     */
    public boolean isIsObserver()
    {
        return isObserver;
    }

    /**
     * @param isObserver the isObserver to set
     */
    public void setIsObserver(boolean isObserver)
    {
        this.isObserver = isObserver;
    }
}
