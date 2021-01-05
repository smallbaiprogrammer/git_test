import tkinteras tk
 
import random
 
import threading
 
import time
 
def dow():
 
window = http://tk.Tk()
 
width = window.winfo_screenwidth()
 
height = window.winfo_screenheight()
 
a = random.randrange(0, width)
 
b = random.randrange(0, height)
 
window.title('你是傻子')
 
window.geometry("200x50" +"+" +str(a) +"+" +str(b))
 
tk.Label(window,
 
text='你就是个傻子！',# 标签的文字
 
bg='Red',# 背景颜色
 
font=('楷体',17),# 字体和字体大小
 
width=15,height=2 # 标签长宽
 
).pack()# 固定窗口位置
 
window.mainloop()
 
threads = []
 
for iin range(100):# 需要的弹框数量
 
t = threading.Thread(target=dow)
 
threads.append(t)
 
time.sleep(0.1)
 
threads[i].start()