#!/usr/bin/env python
#-*- coding: utf-8 -
import re
import bs4
from bs4 import BeautifulSoup
import requests
def get_html(url):
    try:
        r = requests.get(url, timeout=30)
        r.raise_for_status()
        r.encoding = r.apparent_encoding
        return r.text
    except:
        return " ERROR "

def getXML(URL):
    xml = []
    x = get_html(URL)
    soup = BeautifulSoup(x,"html.parser")
    for link in soup.select('td > a'):
        xml.append(link.get('href'))

    xml.pop(0)
    # 删除字符串中的 Python注释
    # condition = lambda t: t != "foxe_CHS.exe" #(判断符合条件很复杂就不能使用lambda，自己写方法吧)
    condition = lambda t: t != "foxe_CHS.exe" #(判断符合条件很复杂就不能使用lambda，自己写方法吧)
    xml = list(filter(condition, xml))
    for i in xml:
        print(i)
    return xml


if __name__ == '__main__':
    URL = 'http://218.94.6.179/system_xt/xml/beishi/'
    xmlPath = getXML(URL)