import React from "react";
import i18next from "i18next";
import { Button, ButtonGroup } from "react-bootstrap";

const languageMap = {
  "en-GB": { label: "en", dir: "ltr", active: true },
  ru: { label: "ru", dir: "ltr", active: false }
};

const LanguageSelect = () => {
  const selected = localStorage.getItem("i18nextLng") || "en";
  const [checked, setChecked] = React.useState(false);
  const [menuAnchor, setMenuAnchor] = React.useState(null);
  React.useEffect(() => {
    document.body.dir = languageMap[selected].dir;
  }, [menuAnchor, selected]);

  return (
    <div>
        <ButtonGroup>
            {Object.keys(languageMap)?.map(item => (
                <Button variant="link" size="sm"
                    checked={checked}
                    key={item}
                    onChange={(e) => setChecked(e.currentTarget.checked)}
                    onClick={() => { i18next.changeLanguage(item); setMenuAnchor(null);}}
                >
                    {languageMap[item].label}
                </Button>
            ))}
        </ButtonGroup>
    </div>
  );
};

export default LanguageSelect;