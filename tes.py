
解决  hash 冲突的几种方法
hashmap 是采用 拉链法
Threadlocal 采用的是开发寻址法
还有一种是再寻址法


Mvcc 版本控制的策略来实现的 乐观锁在数据库中的实现方式 
相当于存在一个缓存层在数据库被修改时记录前一个版本的状态  这个缓存层隐藏在每列后面

print(ACID)

原子性 一致性  隔离性 持久性


并发事务带来的问题

脏读  两个事务同时访问同一个数据  第一个事务将数据修改了 但是第二个事务读取的是修改之前的数据
丢失修改 第一个事务在修改数据的时候，第二个事务也在修改数据，这样就导致第一个修改丢失
不可重复读 一个事务中要读取两次数据，在第一次读完之后，该数据被其他事务修改了，第二次读取数据和第一次读取的数据是不同的，所以事务提交的数据可能与预期不同
幻读 一个事务读了几行数据，另一个事务插入了几行数据，前事务中就会出现原本不存在的数据

读取未提交  运行读取未提交的数据变更 可能会导致 脏读 幻读 不可重复读
读取可提交  运行读取并非事务已提交的数据 可以阻止脏读
可重复读  可重复读 对同一字段的多次读取结果都是一样的
可串行化  最高的隔离级别，所有事务必须串行执行，每一时刻只能由一个事务正在执行

事物之间互不影响
事务提交之后不可变
执行事务后，数据库从一个状态进入另一个状态

事关数据库索引

存储引擎
InnoDB 
MyISAM
Memory
Achive

不同存储引擎的不同的特点是不同的 
主要 MyISAM 和  InnoDB 的 区别  


聚簇索引
InnoDB 采用的是 聚簇索引 MyISAM 采用的是非聚簇索引 
将主键存储到B+树，叶子节点来存储数据，区别是当以非主键索引进行查找数据时，聚簇索引是在一棵B+树上查找主键，然后再从主键的树上查找
数据，非聚簇索引的叶子节点存储的数据其实是数据的引用，查找到叶子节点之后，再经过IO 才能找到数据，若是采用非主键查找，将会在辅助索引树上来查找数据 
隔离级别

读取
出现的问题


锁

大表优化 


SQL 语句联系   

MYSQL的内容全部搞定理论知识内容全部搞定
今天到周三晚上

总体上分为四个部分 

SQL 语句练习 
索引
事务
优化

每天一个数据结果和算法  外加  SQL 语句的题
 