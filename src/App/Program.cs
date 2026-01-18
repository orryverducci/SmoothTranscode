/*
 * This file is part of SmoothTranscode.
 *
 * SmoothTranscode is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * SmoothTranscode is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with SmoothTranscode. If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using Avalonia;

namespace SmoothTranscode.App;

/// <summary>
/// Provides the main functionality for the application.
/// </summary>
internal static class Program
{
    /// <summary>
    /// The entry point for the application.
    /// </summary>
    /// <param name="args">The command line arguments the application is launched with.</param>
    [STAThread]
    public static void Main(string[] args) =>
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

    /// <summary>
    /// Creates the builder used to set up and launch the application.
    /// </summary>
    /// <returns>The application builder.</returns>
    private static AppBuilder BuildAvaloniaApp() =>
        AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace();
}
