# -*- coding = utf-8 -*-
# 定向爬虫
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
    except RuntimeError:
        return " ERROR "

def getXMLPath(URL):
    xml = []
    x = get_html(URL)
    soup = BeautifulSoup(x,"html.parser")
    for link in soup.select('td > a'):
        xml.append(link.get('href'))
    xml.pop(0)
    condition = lambda t: t != "foxe_CHS.exe" #(判断符合条件很复杂就不能使用lambda，自己写方法吧)
    xml = list(filter(condition, xml))
    return xml

def getXML(xmlPath):
    reg = "xml$"
    XML = []
    for i in xmlPath:
        if (re.findall(reg, i)):
            XML.append(temp[0]+ i)
    return XML

def openXML(xml):
    pass
if __name__ == '__main__':
    URL = 'http://218.94.6.179/system_xt/xml/'
    xmlPath = getXMLPath(URL)
    temp = []
    for i in xmlPath:
        temp.append(URL+i)
    # http://218.94.6.179/system_xt/xml/beishi/
    # temp[0]= "http://218.94.6.179/system_xt/xml/sujiao/"
    xml = getXMLPath(temp[0])
    RealXML = []
    RealXML = getXML(xml)
    # http://218.94.6.179/system_xt/xml/beishi/shuxue1.xml
    print(RealXML[0])

