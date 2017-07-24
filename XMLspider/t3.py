# -*- coding: utf-8 -*-
import os
import sys
import FunXMl as Fun

walk_dir = "./xml/"
print('walk_dir = ' + walk_dir)
print('walk_dir (absolute) = ' + os.path.abspath(walk_dir))
walk_dir = os.path.abspath(walk_dir)
sum = 0
s = set([])
for root, subdirs, files in os.walk(walk_dir):
    print('--\nroot = ' + root)
    list_file_path = os.path.join(root, 'my-directory-list.txt')
    # print('list_file_path = ' + list_file_path)
    for subdir in subdirs:
        print('\t- subdirectory ' + subdir)
    for filename in files:
        file_path = os.path.join(root, filename)
        file_size = os.path.getsize(file_path)
        file_type = filename.split('.')[-1]  # 获取目标文件格式
        if(file_type=="xml"):
            if(file_size>365):
                sum +=1
                print(file_path)
                s = Fun.getAttr(file_path)
                #print('\t- 文件 %s (路径: %s   大小：%s)' % (filename, file_path, file_size))
    print('共%d文件'%sum)
for i in s:
    print(i)