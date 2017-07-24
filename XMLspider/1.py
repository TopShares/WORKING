# -*- coding: utf-8 -*-
from lxml import etree
from io import StringIO, BytesIO

path = r'C:\Users\Administrator\Desktop\XMLspider\xml\beishi\shuxue4.xml'
tree = etree.parse(path)
walkAll = tree.getiterator()
s=set([])
for elt in walkAll:
    #print(elt.attrib)
    s.add(elt.tag)
    for i in elt.attrib:
        #print(i)
        s.add(i)
    #print(elt.tag)
    #print(elt.tag)
    #print(elt.items())
    #print(elt.keys())
    #print(elt.values())

for i in s:
    print(i)