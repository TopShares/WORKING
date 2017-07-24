# -*- coding: utf-8 -*-
# 定向爬虫
import os
import shutil

def getPath(path):
    walk_dir = path
    print('walk_dir (absolute) = ' + os.path.abspath(walk_dir))
    walk_dir = os.path.abspath(walk_dir)
    # this folder is custom
    for parent, dirnames, filenames in os.walk(walk_dir):
        # case 1:
        for dirname in dirnames:
            print("parent folder is:" + parent)
            print("dirname is:" + dirname)
            # case 2
        for filename in filenames:
            print("parent folder is:" + parent)
            print("filename with full path:" + os.path.join(parent, filename))

def getallfiles(path):
    path = os.path.abspath(path)
    allfile=[]
    for dirpath,dirnames,filenames in os.walk(path):
        for dir in dirnames:
            allfile.append(os.path.join(dirpath,dir))
        for name in filenames:
            allfile.append(os.path.join(dirpath, name))
    return allfile

if __name__ == "__main__":
    walk_dir = ".xml"
    getPath(walk_dir)