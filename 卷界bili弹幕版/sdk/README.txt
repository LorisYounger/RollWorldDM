

SDK下载地址(.net 4): http://soft.ceve-market.org/bilibili_dm/sdk.7z . 

压缩包内包含一个DLL和对应的XML文档, 新建项目并引用该DLL, 继承类 BilibiliDM_PluginFramework.DMPlugin .

具体可以查看样例文件, 以及可以利用VS的对象浏览器查看DMPlugin的内容.


***

以下是若干注意点.

Start() Stop() Admin() 三个方法均是在UI主线程呼叫, 请勿阻塞该方法.

不论插件是否被启用, 事件Connected()和Disconnected()均会发生, 请正确处理.

事件Connected(),Disconnected(),ReceivedDanmaku(),ReceivedRoomCount(), 均认为会在新线程中呼叫, 请注意WPF的线程特性避免在事件回调中直接调用UI元素.

为保证以后扩展性所有事件的第一个参数 sender 暂时均传入null.

Disconnected()事件两个参数均会传入null, 但是只要发生该事件就必然是已经断开连接.

实际上, DMPlugin.RoomId 保存当前已连接的房间号, 若该属性为null, 则为未连接.

ReceivedRoomCount()的呼叫时机是以服务器发回才呼叫, 通常连接上之后服务器便会发回在线数, 每一次KeepAlive信号之后(现定为60秒)服务器也会发回在线数.

***

DanmakuModel 特别说明:

每从服务器上收到一个可辨别的消息, 均会调用ReceivedDanmaku()事件, DanmakuModel.MsgType 将定义该消息的类别, 如下:

MsgTypeEnum.Comment: 弹幕信息, 使用CommentText, CommentUser, isAdmin, isVIP属性

MsgTypeEnum.GiftSend: 礼物信息, 有观众赠送礼物时发生, 使用GiftName, GiftUser, Giftrcost, GiftNum 属性

MsgTypeEnum.GiftTop: 消费排行榜, 使用GiftRanking属性

MsgTypeEnum.Welcome: 欢迎观众进入, 有特殊观众(老爷和管理)进入直播间时发生, 使用CommentUser, isAdmin, isVIP属性

MsgTypeEnum.LiveStart, MsgTypeEnum.LiveEnd: 望文生義

***

利用Log()和AddDM()方法可以输出日志和弹幕