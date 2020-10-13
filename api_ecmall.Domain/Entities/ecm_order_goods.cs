using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Entities
{
    /// <summary>
    /// 订单商品表
    /// </summary>
    public class ecm_order_goods
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int rec_id { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public int order_id { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int goods_id { get; set; }
        /// <summary>
        /// 商品名
        /// </summary>
        public string goods_name { get; set; }
        /// <summary>
        /// 规格ID
        /// </summary>
        public int spec_id { get; set; }

        /// <summary>
        /// 规格说明
        /// </summary>
        public string specification { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal price { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int quantity { get; set; }
        /// <summary>
        /// 商品图片地址
        /// </summary>
        public string goods_image { get; set; }
        /// <summary>
        /// 是否评定
        /// </summary>
        public int evaluation { get; set; }

        /// <summary>
        /// 评论
        /// </summary>
        public string comment { get; set; }
        /// <summary>
        /// 是否用积分值(信誉积分)
        /// </summary>
        public int credit_value { get; set; }
        /// <summary>
        /// 卖家好评度
        /// </summary>
        public int seller_evaluation { get; set; }
        /// <summary>
        /// 卖家评论
        /// </summary>
        public string seller_comment { get; set; }
        /// <summary>
        /// 卖家信用度
        /// </summary>
        public int seller_credit_value { get; set; }

        /// <summary>
        /// 内容符合度
        /// </summary>
        public int evaluation_desc { get; set; }
        /// <summary>
        /// 服务好评度
        /// </summary>
        public int evaluation_service { get; set; }
        /// <summary>
        /// 发货速度好评度
        /// </summary>
        public int evaluation_speed { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public string is_valid { get; set; }
        /// <summary>
        /// 团购ID
        /// </summary>
        public int group_id { get; set; }

        /// <summary>
        /// 商品原价
        /// </summary>
        public decimal goods_old_price { get; set; }
        /// <summary>
        /// 1默认2团购商品3限时折扣商品
        /// </summary>
        public int goods_type { get; set; }
        /// <summary>
        /// 促销活动ID（团购ID/限时折扣ID）与goods_type搭配使用
        /// </summary>
        public int promotions_id { get; set; }
    }
}
