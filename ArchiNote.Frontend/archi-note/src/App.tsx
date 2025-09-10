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
