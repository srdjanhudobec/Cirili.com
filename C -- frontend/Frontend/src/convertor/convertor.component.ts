import { Component } from '@angular/core';

@Component({
  selector: 'app-convertor',
  templateUrl: './convertor.component.html',
  styleUrls: ['./convertor.component.css']
})
export class ConvertorComponent {

  latinicaUCirilicu(latinicaText: string): string {
    const latinica: Record<string, string> = {
      'a': 'а', 'b': 'б', 'c': 'ц', 'č': 'ч', 'ć': 'ћ', 'd': 'д', 'đ': 'ђ', 'e': 'е', 'f': 'ф', 'g': 'г',
      'h': 'х', 'i': 'и', 'j': 'ј', 'k': 'к', 'l': 'л', 'lj': 'љ', 'm': 'м', 'n': 'н', 'nj': 'њ', 'o': 'о',
      'p': 'п', 'r': 'р', 's': 'с', 'š': 'ш', 't': 'т', 'u': 'у', 'v': 'в', 'z': 'з', 'ž': 'ж','A': 'А', 'B': 'Б', 'C': 'Ц', 'Č': 'Ч', 'Ć': 'Ћ', 'D': 'Д', 'Đ': 'Ђ', 'E': 'Е', 'F': 'Ф', 'G': 'Г',
      'H': 'Х', 'I': 'И', 'J': 'Ј', 'K': 'К', 'L': 'Л', 'LJ': 'Љ', 'M': 'М', 'N': 'Н', 'NJ': 'Њ', 'O': 'О',
      'P': 'П', 'R': 'Р', 'S': 'С', 'Š': 'Ш', 'T': 'Т', 'U': 'У', 'V': 'В', 'Z': 'З', 'Ž': 'Ж'
    };
  
    let cirilicaText = '';
  
    for (let i = 0; i < latinicaText.length; i++) {
      let char = latinicaText[i];
  
      if (char === 'l'  && latinicaText[i+1]?.toLowerCase() === 'j') {
        cirilicaText += 'љ';
        i++;
      } 
      else if (char === 'n' && latinicaText[i+1]?.toLowerCase() === 'j') {
        cirilicaText += 'њ';
        i++;
      }
      else if (char === 'N' && latinicaText[i+1]?.toLowerCase() === 'j') {
        cirilicaText += 'Њ';
        i++;
      }
      else if (char === 'L' && latinicaText[i+1]?.toLowerCase() === 'j') {
        cirilicaText += 'Љ';
        i++;
      } else {
        cirilicaText += latinica[char] || char;
      }
    }
    console.log(cirilicaText)
    return cirilicaText;
  }
  
  konvertuj() {
    const inputTextElement = document.getElementById('inputText') as HTMLInputElement;
  const outputTextElement = document.getElementById('outputText') as HTMLInputElement;

  if (inputTextElement && outputTextElement) {
    const inputText = inputTextElement.value;
    const outputText = this.latinicaUCirilicu(inputText);
    outputTextElement.value = outputText;
  }
  }
}
