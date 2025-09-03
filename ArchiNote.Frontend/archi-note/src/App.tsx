import "@fontsource/roboto/300.css";
import "@fontsource/roboto/400.css";
import "@fontsource/roboto/500.css";
import "@fontsource/roboto/700.css";
import "./App.css";
import { ThemeProvider, CssBaseline, darkTheme } from "./assets/theme";
import { BrowserRouter } from "react-router-dom";
import { AppRouter } from "./router/AppRouter";

function App() {
  return (
    <BrowserRouter>
      <ThemeProvider theme={darkTheme}>
        <CssBaseline />
        <AppRouter />
      </ThemeProvider>
    </BrowserRouter>
  );
}

export default App;
