# ADR 0001: Val av Azure Container Apps för CloudAPI

## Metadata
* **Datum:** 2026-05-04
* **Status:** Föreslagen
* **Beslutsfattare:** [Joco, Lisa, Robin, Liza och Rolf]
* **Relaterat:** [Länk till ticket/issue/spike]

## Kontext
Vårt uppdrag är att flytta ett äldre system till molnet. Systemet kommer att brytas ner till **3 fristående mikrotjänster**. Systemet har ett extremt trafikmönster och måste kunna **klara av tunga trafiktoppar runt löning**, för att därefter ha **nästan noll trafik på helgerna**. Detta kräver ett plattformsbeslut som kan hantera oregelbunden last på ett kostnadseffektivt sätt.

## Beslut
Vi har beslutat att hosta våra mikrotjänster i **Azure Container Apps**.

## Alternativ som utvärderades

**1. Azure Container Apps (Valt alternativ)**
* **Fördelar:** Plattformen är serverlös, skräddarsydd för mikrotjänster och har inbyggd händelsestyrd **autoscale**. Den kan dynamiskt skala upp vid löning och automatiskt **skala ner till noll instanser ("scale-to-zero")** på helgerna, vilket sparar pengar när det inte finns någon trafik.
* **Nackdelar/Konsekvenser:** Kräver att vi paketerar applikationerna i **Docker-containrar**, vilket innebär att teamet måste ha eller bygga upp **Docker-kunskap**.

**2. Azure App Service (Bortvalt alternativ)**
* **Fördelar:** Fantastiskt enkelt att komma igång med.
* **Nackdelar:** Passar bäst för **traditionella och monolitiska webbapplikationer**. Matchar inte vårt behov av mikrotjänster lika bra och saknar Container Apps optimerade modell för att skala ner helt till noll.

## Konsekvenser
* **Drift & Utveckling:** Vi behöver anpassa vår CI/CD-pipeline för att bygga och tagga images till ett container registry. Vi slipper dock hantera den underliggande komplexiteten av att orkestrera ett helt Kubernetes-kluster själva, då Microsoft sköter detta bakom kulisserna.
* **Kompetens:** Inlärningskurva för teamet gällande containerisering.

## Uppföljning
* Vi kommer att kontinuerligt utvärdera beslutet och mäta prestanda, incidenter och kostnader med hjälp av **observability** (loggar).
