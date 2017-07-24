# coding:utf-8
from lxml import etree
import csv

questions = ['name', 'quest', 'favorite color']
answers = ['lancelot', 'the holy grail', 'blue']
for q, a in zip(questions, answers):
   print('What is your {0}?  It is {1}.'.format(q, a))

print("\n\n\n\n")
path = r'C:\Users\Administrator\Desktop\XMLspider\xml\beishi\shuxue4.xml'
xml = etree.parse(path)  # 读取test.xml文件
tree = etree.parse(path)

walkAll = tree.getiterator()
for elt in walkAll:
    #print(elt.tag)
    #print(elt.items())
    #print(elt.keys())
    #print(elt.values())
    pass
# root = xml.getroot()  # 获取根节点
# 获取属性
# print(root.items())  # 获取全部属性和属性值
# print(root.keys())  # 获取全部属性
# print(root.get('version', ''))  # 获取具体某个属性
#
# for node in root.getchildren():
#     print(node.tag) #输出节点的标签名
