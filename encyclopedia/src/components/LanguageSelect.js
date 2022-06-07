import React from "react";
import i18next from "i18next";
import { ButtonGroup } from "react-bootstrap";

const languageMap = {
  "en-GB": { label: "en-GB", dir: "ltr", active: true },
  ru: { label: "ru", dir: "ltr", active: false }
};

const LanguageSelect = () => {
  const selected = localStorage.getItem("i18nextLng") || "en";
  const [checkedEn, setCheckedEn] = React.useState('');
  const [checkedRu, setCheckedRu] = React.useState('hidden-text-color');

  React.useEffect(() => {
    document.body.dir = languageMap[selected].dir;
  }, [selected]);

  return (
    <ButtonGroup className="buttonGroup-center">
      <h4 
        className={checkedEn}
        onClick={() => { 
          i18next.changeLanguage(languageMap["en-GB"].label); 
          setCheckedEn('');
          setCheckedRu('hidden-text-color');
        }}> {'en'}</h4>
      <h4>|</h4>
      <h4 
        className={checkedRu}
        onClick={() => { 
          i18next.changeLanguage(languageMap['ru'].label); 
          setCheckedEn('hidden-text-color');
          setCheckedRu('');
        }}> {'ru'}</h4>
    </ButtonGroup>
  );
};

export default LanguageSelect;