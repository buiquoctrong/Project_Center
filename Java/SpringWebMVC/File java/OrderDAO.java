package org.shoppingcart.dao;

import java.util.List;

import org.shoppingcart.model.CartInfo;
import org.shoppingcart.model.OrderDetailInfo;
import org.shoppingcart.model.OrderInfo;
import org.shoppingcart.model.PaginationResult;
public interface OrderDAO {
	 
    public void saveOrder(CartInfo cartInfo);
 
    public PaginationResult<OrderInfo> listOrderInfo(int page,
            int maxResult, int maxNavigationPage);
    
    public OrderInfo getOrderInfo(String orderId);
    
    public List<OrderDetailInfo> listOrderDetailInfos(String orderId);
 
}