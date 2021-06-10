```
  _____          _____   _____ _    _ _____  ______ 
 / ____|   /\   |  __ \ / ____| |  | |  __ \|  ____|
| |       /  \  | |__) | (___ | |  | | |__) | |__   
| |      / /\ \ |  _  / \___ \| |  | |  _  /|  __|  
| |____ / ____ \| | \ \ ____) | |__| | | \ \| |____ 
 \_____/_/    \_\_|  \_\_____/ \____/|_|  \_\______|
```
 
## Premieberekening auto - Requirements

### Objecten:

#### VOERTUIG
- Vermogen
- Waarde
- Leeftijd (jaar-bouwjaar)

#### VERZEKERINGNEMER
- Leeftijd
- Rijbewijs
- PostCode (4 cijfers)
- Schadevrije jaren

#### DEKKING
- WA
- WA_Plus
- AllRisk

### Premieberekening:

Basispremie WA per jaar:
- Waarde (voertuig / 100 - leeftijd + vermogen in KW / 5) / 3
- Een leeftijd van onder 23 jaar OF korter dan 5j rijbewijs is premie-opslag van 15%
- Postcodes 10xx - 35xx: 5% risico opslag
- Postcodes 36xx - 44xx: 2% risico opslag

Dekking:
- WA plus is 20% duurder
- All Risk is dubele premie

Voor 6e schadevrije jaar en daarboven wordt 5% korting gerekend (5,10,15,20) met een maximum van 65%.

Premie per jaar / 12 is maandpremie.
Voor jaarbetaling geldt 2,5% korting

Het premiebedrag wordt afgerond naar 2 cijfers achter de komma.



