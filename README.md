**Лабораторная работа 1 по предмету "Компьютерная графика". Вариант 11**

**Описание**: десктопное приложение позволяет пользователю выбирать цвет, а также впоследствии интерактивно его изменять, при этом отображая его компоненты в трех различных моделях — XYZ, LAB и HLS. Программа написана при помощи языка C# и средств WPF. 

**Установка**: приложение имеет расширение .exe, что максимально упрощает его использование на операционной системе Windows всех версий. Для его запуска достаточно скачать содержимое репозитория, пройти по пути _lab1 - bin - Debug_  и дважды кликнуть на "lab1.exe".

Главное окно приложения <br /> ![main](/screenshots/main.jpg)

**Использование**: после открытия приложения пользователю будет предложена возможность выбора цвета тремя способами: 
* непосредственно выбрать из палитры (режим Standart отображает палитру из более чем 140 цветов, режим Advanced дает право выбрать любой цвет из цветовой модели RGB при помощи интерактивной палитры, HEX-кода или точных значений RGB значений цвета) <br /> ![Standart](/screenshots/standart.jpg)  ![Advanced](/screenshots/advanced.jpg)

* задать точные значения цвета для каждой из трех моделей в текстовых полях  <br /> ![text](/screenshots/textbox.jpg): 
  * границы диапазона допустимых значений в модели XYZ: X [0..95.047], Y [0..100], Z [0..108.883].
  * в модели LAB: L [0..100], A [-128..128], B [-128..128]
  * в модели HLS: H [0..360], L [0..100], S [0..100]
  _При конвертации из модели XYZ в HLS возможен выход за диапазон допустимых значений цветовой модели RGB (через которую косвенно осуществляется перевод), что может отразиться на точности значений. В этом случае будет показано соответствующее предупреждение_  <br /> ![Warning](/screenshots/warning.jpg)
* перетаскивать ползунки, которые установлены для каждого параметры всех трех моделей.   <br /> ![Slider](/screenshots/slider.jpg)

Изменения значений всех параметров происходят автоматически после модификации любым из трех вышеизложенными методами взаимодействия. 

