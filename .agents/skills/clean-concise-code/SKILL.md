---
name: clean-concise-code
description: >-
  Enforces minimal, concise, KISS & YAGNI coding standards in Foxoft. Eliminates redundant
  null checks, unnecessary wrappers, duplicated logic, and superfluous alternative implementations.
  Use when writing, refactoring, or reviewing C#, LINQ, or SQL code in Foxoft.
---

# Clean, Concise & Minimal Code Skill (Foxoft)

Bu skill Foxoft layihəsində kod yazarkən, refaktorinq edərkən və ya kod yoxlayarkən (code review) təmiz, yığcam, artıq yüklərdən azad və optimal həllər tətbiq etmək üçün təlimat və standartları müəyyən edir.

---
### Əsas Tələblər:
- **Təkrarçılığa yol verməmək (DRY)**: Qarantiyə almaq üçün eyni əməliyyatı təkrar edən kod blokları yazılmamalıdır. Əgər bir kod bloku nəticə verirsə başqa kodlar yazma

## 2. Lazımsız NULL Yoxlamaları

Yalnız həqiqətən `null` olma ehtimalı olan yerlərdə yoxlama aparılmalıdır. Zəmanətli məlum olan yerlərdə `null` müdafiəsi kodu şişirdir və oxunaqlığı azaldır.

### Əsas Tələblər:
- **NULL gəlməyəcəyi məlum olan hallar**:
  - `new` ilə indicə yaradılmış obyekt və kolleksiyalar (məsələn, `new List<T>()`).
  - Dəyər tipləri (`int`, `decimal`, `bool`, `DateTime` və s. əgər `Nullable<T>` deyillərsə).
  - Konstruktorda və ya çərçivə tərəfindən inisializasiya olunmuş sahələr.
- **Lazımsız operatorlar**:
  - Mənasız `?.`, `??`, `if (x == null)` zəncirlərindən qaçınılmalıdır.
  - SQL-də və LINQ sorğularında `NOT NULL` sütunlara `ISNULL(...)` və ya `COALESCE(...)` yazılmamalıdır.
- **Verilənlər bazası (EF Core / SQL) uyğunluğu**:
  - Əgər cədvəldə sütun `NOT NULL` kimi təyin edilibsə (məsələn, `CurrAccCode`, `CreatedDate`), sorğuda və ya C# tərəfində həmin sahə üçün təkrar `null` yoxlanışı edilməməlidir.

## 3. Alternativləri Çoxaltmamaq (Tək və Optimal Həll)

Bir tapşırıq üçün bir optimal və etibarlı həll kifayətdir. Eyni nəticəyə çatan paralel, dublikat və ya alternativ üsullar saxlanmamalıdır.

### Əsas Tələblər:
- **Tək optimal yol**: Problemi həll etmək üçün ən effektiv, professional və layihənin arxitekturasına uyğun 1 həll seçilməli və yalnız o tətbiq olunmalıdır.
- **2-3 fərqli üsulu qarışdırmamaq**: Eyni məqsədə xidmət edən alternativ fallback mexanizmləri, dublikat köməkçi metodlar və ya "həm bu yolla, həm o yolla" yanaşması kodu mürəkkəbləşdirir və dəstəklənməsini çətinləşdirir.
- **Qətiyyətli kod**: Əgər bir əməliyyat uğursuz olarsa, gizli alternativlərə keçmək əvəzinə aydın şəkildə idarə olunmalı və ya xəta bildirməlidir.

