

SDK���ص�ַ(.net 4): http://soft.ceve-market.org/bilibili_dm/sdk.7z . 

ѹ�����ڰ���һ��DLL�Ͷ�Ӧ��XML�ĵ�, �½���Ŀ�����ø�DLL, �̳��� BilibiliDM_PluginFramework.DMPlugin .

������Բ鿴�����ļ�, �Լ���������VS�Ķ���������鿴DMPlugin������.


***

����������ע���.

Start() Stop() Admin() ��������������UI���̺߳���, ���������÷���.

���۲���Ƿ�����, �¼�Connected()��Disconnected()���ᷢ��, ����ȷ����.

�¼�Connected(),Disconnected(),ReceivedDanmaku(),ReceivedRoomCount(), ����Ϊ�������߳��к���, ��ע��WPF���߳����Ա������¼��ص���ֱ�ӵ���UIԪ��.

Ϊ��֤�Ժ���չ�������¼��ĵ�һ������ sender ��ʱ������null.

Disconnected()�¼������������ᴫ��null, ����ֻҪ�������¼��ͱ�Ȼ���Ѿ��Ͽ�����.

ʵ����, DMPlugin.RoomId ���浱ǰ�����ӵķ����, ��������Ϊnull, ��Ϊδ����.

ReceivedRoomCount()�ĺ���ʱ�����Է��������زź���, ͨ��������֮���������ᷢ��������, ÿһ��KeepAlive�ź�֮��(�ֶ�Ϊ60��)������Ҳ�ᷢ��������.

***

DanmakuModel �ر�˵��:

ÿ�ӷ��������յ�һ���ɱ�����Ϣ, �������ReceivedDanmaku()�¼�, DanmakuModel.MsgType ���������Ϣ�����, ����:

MsgTypeEnum.Comment: ��Ļ��Ϣ, ʹ��CommentText, CommentUser, isAdmin, isVIP����

MsgTypeEnum.GiftSend: ������Ϣ, �й�����������ʱ����, ʹ��GiftName, GiftUser, Giftrcost, GiftNum ����

MsgTypeEnum.GiftTop: �������а�, ʹ��GiftRanking����

MsgTypeEnum.Welcome: ��ӭ���ڽ���, ���������(��ү�͹���)����ֱ����ʱ����, ʹ��CommentUser, isAdmin, isVIP����

MsgTypeEnum.LiveStart, MsgTypeEnum.LiveEnd: �������x

***

����Log()��AddDM()�������������־�͵�Ļ