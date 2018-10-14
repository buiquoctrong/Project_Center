/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package mychessmate.network;

import mychessmate.*;
import java.io.IOException;
import java.util.ArrayList;

/**
 *
 * @author TranCamTu
 */
public class Table
{//Table: {two player, one chessboard and x observers}

    private Client clientPlayer1;                    // Client đại diện player thứ nhất
    private Client clientPlayer2;                    // Client đại diện cho player thứ 2
    private ArrayList<Client> clientObservers;       // Các client xem ván đánh
    public String password;                          // Password của ván game
    private boolean canObserversJoin;                // Báo còn có thể join vào xem không
    private boolean enableChat;                      // Báo cáo cho phép chat không
    //Phát triển cho chế độ xin đi lại
    //private ArrayList<Move> movesList;               // Danh sách các nước đi
    private Move move;                      // Vị trí mới nhất vừa di chuyển
    private MyChessmate chessmate;

    Table(String password, boolean canObserversJoin, boolean enableChat)
    {
        this.password = password;
        this.enableChat = enableChat;
        this.canObserversJoin = canObserversJoin;

        if (canObserversJoin)
        {
            clientObservers = new ArrayList<>();
        }

        //movesList = new ArrayList<Move>();
    }

    //Gửi lượt di chuyển tới tất cả client trừ client vừa di chuyển
    public void sendMoveToOther(Client sender, int source_location, int destination) throws IOException
    {
        // Thông báo ra console
        print("running function: sendMoveToOther(" + sender.nick + ", " + source_location + ", " + destination);

        if (sender == clientPlayer1 || sender == clientPlayer2) //Chỉ có thể 1 trong 2 player có thể di chuyển
        {
            Client receiver = (clientPlayer1 == sender) ? clientPlayer2 : clientPlayer1; // gửi tới 1 trong 2 play đang chờ
            receiver.output.writeUTF("#move");
            receiver.output.writeInt(source_location);
            receiver.output.writeInt(destination);
            print(receiver.nick +" is sending.");
            receiver.output.flush();
            
            if (canObserversJoin())
            {
                for (Client observer : clientObservers)
                {
                    observer.output.writeUTF("#move");
                    observer.output.writeInt(source_location);
                    observer.output.writeInt(destination);
                    observer.output.flush();
                }
            }
        }
    }

    // Gửi thông tin đến tất cả client trừ client đã viết
    public void sendToAll( Client sender, String msg ) throws IOException
    {
        if( sender == clientPlayer1 || sender == clientPlayer2 )
        {
            Client receiver = (clientPlayer1 == sender) ? clientPlayer2 : clientPlayer1;
            receiver.output.writeUTF( msg );
            receiver.output.flush();
            
            if (canObserversJoin())
            {
                for (Client observer : clientObservers)
                {
                    observer.output.writeUTF( msg );
                    observer.output.flush();
                }
            }            
        }
    }
    
    // Chỉ gửi tin nhắn đến người đang chơi với mình
    public void sendToOtherPlayer( Client sender, String msg ) throws IOException
    {
        if( sender == clientPlayer1 || sender == clientPlayer2 )
        {
            Client receiver = (clientPlayer1 == sender) ? clientPlayer2 : clientPlayer1;
            receiver.output.writeUTF( msg );
            receiver.output.flush();     
        }
    }

    //Báo lỗi kết nối đến người chơi cùng bàn
    //send only if sender is player (not observer)
    public void sendErrorConnectionToOther(Client sender) throws IOException
    {
        print("SendErrorConnectionToOther(" + sender.nick);

        if (sender == clientPlayer1 || sender == clientPlayer2) // Nếu 1 trong 2 là player bị mất kết nối
        {
            if (clientPlayer1 != sender)
            {
                clientPlayer1.output.writeUTF("#errorConnection");
                clientPlayer1.output.flush();
            }
            if (clientPlayer2 != sender)
            {
                clientPlayer2.output.writeUTF("#errorConnection");
                clientPlayer2.output.flush();
            }

            if (canObserversJoin())
            {
                for (Client observer : clientObservers)
                {
                    observer.output.writeUTF("#errorConnection");
                    observer.output.flush();
                }
            }
        }
    }
    //Gọi Player1 start game
    public void sendStartGameToPlayer1()throws IOException{
        print("SendStartGameToPlayer1");
        clientPlayer1.output.writeUTF("#StartGame");
        clientPlayer1.output.flush();
    }
    //Gửi tin nhắn đến tất cả client từ 1 client nào đó
    public void sendMessageToAll(String str) throws IOException
    {
        print("SendMessageToAll(" + str);

        if (clientPlayer1 != null)
        {
            clientPlayer1.output.writeUTF("#message");
            clientPlayer1.output.writeUTF(str);
            clientPlayer1.output.flush();
        }

        if (clientPlayer2 != null)
        {
            clientPlayer2.output.writeUTF("#message");
            clientPlayer2.output.writeUTF(str);
            clientPlayer2.output.flush();
        }

        if (canObserversJoin())
        {
            for (Client observer : clientObservers)
            {
                observer.output.writeUTF("#message");
                observer.output.writeUTF(str);
                observer.output.flush();
            }
        }
    }

    // Báo đã hết người chơi, đã đủ người chơi
    public boolean isAllPlayers()
    {
        //is it all playing players
        return !(clientPlayer1 == null || clientPlayer2 == null);
    }

    // Kiểm tra xem có Người xem nào không
    public boolean isObservers()
    {
        return !clientObservers.isEmpty();
    }
    
    // Kiểm tra có thể cho người xem vào phòng không
    public boolean canObserversJoin()
    {
        return this.canObserversJoin;
    }

    // Thêm một Player mới
    // thứ tự là 1 rồi mối đến 2
    public void addPlayer(Client client)
    {
        if (clientPlayer1 == null)
        {
            clientPlayer1 = client;
            print("Player1 connected");
        }
        else if (clientPlayer2 == null)
        {
            clientPlayer2 = client;
            print("Player2 connected");
        }
    }
    
    // Thêm người xem vào phòng
    public void addObserver(Client client)
    {
        clientObservers.add(client);
    }
    
    /**
     * Get client 1 hay là người chơi 1
     * @return Client1
     */
    public Client getPlayerOne(){
        return clientPlayer1;
    }
    /**
     * Gét client 2 hay là người chơi 2
     * @return Client2
     */
    public Client getPlayerTwo(){
        return clientPlayer2;
    }
    /**
     * Get client là Observers 
     * @return Client is Observers
     */
    public ArrayList<Client> getObservers(){
        return clientObservers;
    }
    
    private void print(String msg){
        System.out.println("Table: "+ msg);
    }    
}
